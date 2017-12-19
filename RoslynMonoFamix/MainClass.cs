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

using FAMIX;

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
            ValidateArgs(args);//validates arguments
			string path = Assembly.GetAssembly(typeof(MainClass)).Location;
			Console.WriteLine("--->>>" + path);
			path = path.Replace("RoslynMonoFamix.exe", "");
			string solutionPath = args[0];
	
			var metamodel = FamixModel.Metamodel();

            var msWorkspace = MSBuildWorkspace.Create();
            var solution = await msWorkspace.OpenSolutionAsync(solutionPath);
            var importer = new InCSharp.InCSharpImporter(metamodel);
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
                        var visitor = new ModelVisitor(semanticModel, importer);
                        visitor.Visit(syntaxTree.GetRoot());
                    }
                }
            }

            metamodel.ExportMSEFile(args[1]);
        }

        private static void ValidateArgs(string[] args)
        {
            //validate we receive solution file path and output file path

        }
    }
}
