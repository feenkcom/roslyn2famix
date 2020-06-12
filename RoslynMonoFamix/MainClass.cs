using System;
using System.Linq;
using System.Reflection;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using System.Collections.Generic;
using System.IO;
using Model;
using System.Text;

using FAMIX;

namespace RoslynMonoFamix
{
    class MainClass
    {
        static void Main(string[] args)
        { 
            try
            {
                //The code that causes the error goes here.
           
            ValidateArgs(args);//validates arguments
            string path = Assembly.GetAssembly(typeof(MainClass)).Location;
            Console.WriteLine("Current executable location" + path);
            path = path.Replace("RoslynMonoFamix.exe", "");
            string solutionPath = args[0];

            var metamodel = FamixModel.Metamodel();

            var msWorkspace = MSBuildWorkspace.Create();

            var solution = msWorkspace.OpenSolutionAsync(solutionPath).Result;
            Uri uri = null;
            try
            {
                uri = new Uri(solutionPath); ;
            }
            catch (UriFormatException e)
            {
                var currentFolder = new Uri(Environment.CurrentDirectory + "\\");
                uri = new Uri(currentFolder, solutionPath.Replace("\\", "/"));
                Console.WriteLine(e.StackTrace);
            }

            var ignoreFolder = Path.GetDirectoryName(uri.AbsolutePath);

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


        private static void ValidateArgs(string[] args)
        {
            //validate we receive solution file path and output file path

        }
    }
}
