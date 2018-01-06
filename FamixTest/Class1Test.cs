using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using System.Collections.Generic;

using FAMIX;

namespace FamixTest
{
	[TestClass]
	public class Class1Test : SampleSystemLoader
	{     
		[TestMethod]
		public void ClassWasIngested() => Assert.IsNotNull(importer.Types.Named("SampleProject.Basic.Class1"));
    }
}
