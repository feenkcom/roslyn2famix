using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.Build.Locator;
using System.Collections.Generic;
using System.IO;
using Model;
using System.Text;

using FAMIX;
using System.Diagnostics;
using System.Collections.Immutable;

namespace RoslynMonoFamix
{
    class MainClass
    {
        static async Task Main(string[] args)
        {
            try
            {
                ValidateArgs(args);//validates arguments
                string path = Assembly.GetAssembly(typeof(MainClass)).Location;
                Console.WriteLine("--->>>" + path);
                path = path.Replace("RoslynMonoFamix.exe", "");
                string solutionPath = args[0];

                MSBuildLocator.RegisterDefaults();

                // Attempt to set the version of MSBuild.
                VisualStudioInstance instance;
                var visualStudioInstances = MSBuildLocator.QueryVisualStudioInstances().ToArray();
                if (args.Count() < 3)
                {
                    instance = visualStudioInstances.Length == 1
                        // If there is only one instance of MSBuild on this machine, set that as the one to use.
                        ? visualStudioInstances[0]
                        // Handle selecting the version of MSBuild you want to use.
                        : SelectVisualStudioInstance(visualStudioInstances);
                }
                else
                {
                    instance = visualStudioInstances[int.Parse(args[2])];
                }

                Console.WriteLine($"Using MSBuild at '{instance.MSBuildPath}' to load projects.");

                var metamodel = FamixModel.Metamodel();

                var msWorkspace = MSBuildWorkspace.Create();
                msWorkspace.LoadMetadataForReferencedProjects = true;

                // Attach progress reporter so we print projects as they are loaded.
                var solution = await msWorkspace.OpenSolutionAsync(solutionPath, new ConsoleProgressReporter());
                Console.WriteLine($"Finished loading solution '{solutionPath}'");

                // print causes of errors if any
                printDiagnostics(msWorkspace);

                var ignoreFolder = Path.GetDirectoryName(solutionPath);
                var importer = new InCSharp.InCSharpImporter(metamodel, ignoreFolder);
                var documents = new List<Document>();

                for (int i = 0; i < solution.Projects.Count<Project>(); i++)
                {
                    var project = solution.Projects.ElementAt<Project>(i);

                    for (int j = 0; j < project.Documents.Count<Document>(); j++)
                    {
                        var document = project.Documents.ElementAt<Document>(j);
                        if (document.SupportsSyntaxTree)
                        {
                            System.Console.Write("(project " + (i + 1) + " / " + solution.Projects.Count<Project>() + ")");
                            System.Console.WriteLine("(document " + (j + 1) + " / " + project.Documents.Count<Document>() + " " + document.FilePath + ")");

                            var syntaxTree = document.GetSyntaxTreeAsync().Result;
                            var compilationAsync = project.GetCompilationAsync().Result;
                            var semanticModel = compilationAsync.GetSemanticModel(syntaxTree);
                            var visitor = new ASTVisitor(semanticModel, importer);
                            visitor.Visit(syntaxTree.GetRoot());
                        }
                    }
                }

                Console.WriteLine($"Export FAMIX model to {args[1]}");
                metamodel.ExportMSEFile(args[1]);

            }
            catch (ReflectionTypeLoadException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (System.Exception exSub in ex.LoaderExceptions)
                {
                    sb.AppendLine(exSub.Message);
                    FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
                    if (exFileNotFound != null)
                    {
                        if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
                        {
                            sb.AppendLine("Fusion Log:");
                            sb.AppendLine(exFileNotFound.FusionLog);
                        }
                    }
                    sb.AppendLine();
                }
                string errorMessage = sb.ToString();
                Console.WriteLine(errorMessage);
                //Display or log the error based on your application.
            }
        }

        /// <summary>
        /// Prints diagnostics information (if any)
        /// </summary>
        /// <param name="msWorkspace"></param>
        private static void printDiagnostics(MSBuildWorkspace msWorkspace)
        {
            ImmutableList<WorkspaceDiagnostic> diagnostics = msWorkspace.Diagnostics;
            if (diagnostics.Count() > 0)
            {
                Console.WriteLine("---> Diagnostics");
                foreach (var diagnostic in diagnostics)
                {
                    Console.WriteLine(diagnostic.Message);
                }
            }
        }

        private static void ValidateArgs(string[] args)
        {
            //validate we receive solution file path and output file path
        }

        /// <summary>
        /// Report the progress when opening a solution
        /// </summary>
        private class ConsoleProgressReporter : IProgress<ProjectLoadProgress>
        {
            public void Report(ProjectLoadProgress loadProgress)
            {
                var projectDisplay = Path.GetFileName(loadProgress.FilePath);
                if (loadProgress.TargetFramework != null)
                {
                    projectDisplay += $" ({loadProgress.TargetFramework})";
                }

                Console.WriteLine($"{loadProgress.Operation,-15} {loadProgress.ElapsedTime,-15:m\\:ss\\.fffffff} {projectDisplay}");
            }
        }

        /// <summary>
        /// Ask the user to select one of the installed visual studio instances
        /// </summary>
        /// <param name="visualStudioInstances"></param>
        /// <returns>selected instance</returns>
        private static VisualStudioInstance SelectVisualStudioInstance(VisualStudioInstance[] visualStudioInstances)
        {
            Console.WriteLine("Multiple installs of MSBuild detected please select one:");
            for (int i = 0; i < visualStudioInstances.Length; i++)
            {
                Console.WriteLine($"Instance {i + 1}");
                Console.WriteLine($"    Name: {visualStudioInstances[i].Name}");
                Console.WriteLine($"    Version: {visualStudioInstances[i].Version}");
                Console.WriteLine($"    MSBuild Path: {visualStudioInstances[i].MSBuildPath}");
            }

            while (true)
            {
                var userResponse = Console.ReadLine();
                if (int.TryParse(userResponse, out int instanceNumber) &&
                    instanceNumber > 0 &&
                    instanceNumber <= visualStudioInstances.Length)
                {
                    return visualStudioInstances[instanceNumber - 1];
                }
                Console.WriteLine("Input not accepted, try again.");
            }
        }
    }
}
