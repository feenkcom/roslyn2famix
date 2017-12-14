using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using System.Collections.Generic;


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
            importer = new RoslynMonoFamix.InCSharp.InCSharpImporter(metamodel);
            var msWorkspace = MSBuildWorkspace.Create();
			msWorkspace.WorkspaceFailed += (o, e) =>
			{
				System.Console.WriteLine(e.Diagnostic.Message);
			};

			var solution = msWorkspace.OpenSolutionAsync(solutionPath).Result;

            var documents = new List<Document>();
			foreach (var project in solution.Projects)
			{
				foreach (var document in project.Documents)
				{
					Console.WriteLine("--->>>" + this.GetType().Name);
					var targetFile = this.GetType().Name.Replace("Test", ".cs"); 
					if (document.SupportsSyntaxTree && document.FilePath.EndsWith(targetFile))
					{
						var syntaxTree = document.GetSyntaxTreeAsync().Result;
						var compilationAsync = project.GetCompilationAsync().Result;
						var semanticModel = compilationAsync.GetSemanticModel(syntaxTree);
						var visitor = new ModelVisitor(semanticModel, importer);
						visitor.Visit(syntaxTree.GetRoot());
					}
				}
			}
			metamodel.ExportMSEFile("SampleCode.mse");
		}

	}
}
