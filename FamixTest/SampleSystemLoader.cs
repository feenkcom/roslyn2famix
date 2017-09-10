﻿using System;
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
			string path = Assembly.GetAssembly(typeof(SampleSystemLoader)).Location;
			Console.WriteLine("--->>>" + this.GetType().Name);
			path = path.Replace("FamixTest.dll", "");
			string solutionPath = path + "../../../SampleCode/SampleCode.sln";

			var msWorkspace = MSBuildWorkspace.Create();
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
