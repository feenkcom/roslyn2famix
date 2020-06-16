using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using System.IO;
using RoslynMonoFamix.VB;
using Microsoft.CodeAnalysis;

using Fame;
using Model;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Text;

namespace FamixTest
{
	[TestClass]
	public class SampleSystemLoader
	{
		protected Repository metamodel = FamixModel.Metamodel();

        protected RoslynMonoFamix.InCSharp.InCSharpImporter importer = null;

		[TestInitialize]
		public void LoadSampleSystem()
		{
			string path = Assembly.GetAssembly(typeof(SampleSystemLoader)).Location;
			path = path.Replace("FamixTest.dll", "");
			string solutionPath = path + "../../../SampleCode/SampleCode.sln";
            importer = new RoslynMonoFamix.InCSharp.InCSharpImporter(metamodel, Path.GetDirectoryName(new Uri(solutionPath).AbsolutePath));
            var msWorkspace = MSBuildWorkspace.Create();
			msWorkspace.WorkspaceFailed += (o, e) =>
			{
				System.Console.WriteLine(e.Diagnostic.Message);
			};

			var solution = msWorkspace.OpenSolutionAsync(solutionPath).Result;

            Boolean fileWasFound = false;
			foreach (var project in solution.Projects)
			{
				foreach (var document in project.Documents)
				{
					var targetFile = this.GetType().Name.Replace("Test", ".cs");
					targetFile = targetFile.Replace("VB.cs", ".vb");
					targetFile.Replace("2.cs", "1.cs");
					targetFile.Replace("2.vb", "1.vb");

					if (document.SupportsSyntaxTree && (document.FilePath.Replace("2.cs", "1.cs").EndsWith(targetFile) || document.FilePath.Replace("2.vb", "1.vb").EndsWith(targetFile) ))
					{
						var syntaxTree = document.GetSyntaxTreeAsync().Result;
						System.Console.WriteLine(syntaxTree.ToString());
						var compilationAsync = project.GetCompilationAsync().Result;
						var semanticModel = compilationAsync.GetSemanticModel(syntaxTree);

						var syntax = syntaxTree.GetRoot().NormalizeWhitespace().ToFullString();

						if (document.FilePath.EndsWith(".vb"))
						{
							var visitor = new VBASTVisitor(semanticModel, importer);
							var printer = new VBPrettyPrinter();
							visitor.Visit(syntaxTree.GetRoot());
							printer.Visit(syntaxTree.GetRoot());
						}
						else
						{
							var visitor = new ASTVisitor(semanticModel, importer);
							visitor.Visit(syntaxTree.GetRoot());
						}
						
                        fileWasFound = true;
					}
				}
			}
            if (!fileWasFound) throw new Exception("File was not found!");
			metamodel.ExportMSEFile("SampleCode.mse");
		}
	}
}
