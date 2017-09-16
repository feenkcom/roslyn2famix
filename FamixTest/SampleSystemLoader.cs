using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using System.Collections.Generic;

using Model;
using Fame;

namespace FamixTest
{
	[TestClass]
	public class SampleSystemLoader
	{
		protected Repository metamodel = FamixModel.Metamodel();

		[TestInitialize]
		public void LoadSampleSystem()
		{
			//Environment.SetEnvironmentVariable("VSINSTALLDIR", @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community");
			//Environment.SetEnvironmentVariable("VisualStudioVersion", @"15.0");
		//Environment.SetEnvironmentVariable("MSBUILD_EXE_PATH", @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe");
			string path = Assembly.GetAssembly(typeof(SampleSystemLoader)).Location;
			Console.WriteLine("--->>>" + this.GetType().Name);
			path = path.Replace("FamixTest.dll", "");
			string solutionPath = path + "../../../SampleCode/SampleCode.sln";

			var msWorkspace = MSBuildWorkspace.Create();
			msWorkspace.WorkspaceFailed += (o, e) =>
			{
				var ee = e;
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
						var visitor = new ModelVisitor(metamodel, semanticModel);
						visitor.Visit(syntaxTree.GetRoot());
					}
				}
			}
			metamodel.ExportMSEFile("SampleCode.mse");
		}

	}
}
