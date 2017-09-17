using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using System.Collections.Generic;

using Model;

namespace RoslynMonoFamix
{
    class MainClass
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        public static async Task MainAsync(string[] args)
        {
           
			string path = Assembly.GetAssembly(typeof(MainClass)).Location;
			Console.WriteLine("--->>>" + path);
			path = path.Replace("RoslynMonoFamix.exe", "");
			string solutionPath = path+"../../../SampleCode/SampleCode.sln";
	
			var metamodel = FamixModel.Metamodel();

            var msWorkspace = MSBuildWorkspace.Create();
            var solution = await msWorkspace.OpenSolutionAsync(solutionPath);

            var documents = new List<Document>();
            foreach (var project in solution.Projects)
            {
                foreach (var document in project.Documents)
                {
                    if (document.SupportsSyntaxTree)
                    {
                        var syntaxTree = await document.GetSyntaxTreeAsync();
                        var compilationAsync = await project.GetCompilationAsync();
                        var semanticModel = compilationAsync.GetSemanticModel(syntaxTree);
                        var visitor = new ModelVisitor(metamodel, semanticModel);
                        visitor.Visit(syntaxTree.GetRoot());
                    }
                }
            }

            metamodel.ExportMSEFile("C:/Users/george/out.mse");
			//List<MethodDeclarationSyntax> methods = documents.SelectMany(x => x.GetSyntaxRootAsync().Result.DescendantNodes().OfType<MethodDeclarationSyntax>()).ToList();

			Console.ReadKey();
        }
    }
}
