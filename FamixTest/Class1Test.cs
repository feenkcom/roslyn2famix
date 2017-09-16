using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using System.Collections.Generic;

using Model;

namespace FamixTest
{
	[TestClass]
	public class Class1Test : SampleSystemLoader
	{


		[TestMethod]
		public void TestMethod1()
		{
			Assert.AreEqual("(\n\t(FAMIX.Class (id: 1)\n\t\t(Name 'Class1')))", metamodel.ExportMSEFile(null));
		}
	}
}
