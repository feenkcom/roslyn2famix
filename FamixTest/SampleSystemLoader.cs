using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using System.IO;


using Fame;
using Model;

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
					if (document.SupportsSyntaxTree && document.FilePath.EndsWith(targetFile))
					{
						var syntaxTree = document.GetSyntaxTreeAsync().Result;
						var compilationAsync = project.GetCompilationAsync().Result;
						var semanticModel = compilationAsync.GetSemanticModel(syntaxTree);
						var visitor = new ModelVisitor(semanticModel, importer);
						visitor.Visit(syntaxTree.GetRoot());
                        fileWasFound = true;
					}
				}
			}
            if (!fileWasFound) throw new Exception("File was not found!");
			metamodel.ExportMSEFile("SampleCode.mse");
		}

	}
}
