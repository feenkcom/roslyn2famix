using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp;
using FAMIX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest
{
    [TestClass]
    public class MyPartialClass1Test : SampleSystemLoader
    {
        [TestMethod]
        public void ClassHasTwoMethods() => Assert.AreEqual(3,importer.Types.Named("SampleProject.Basic.MyPartialClass").Methods.Count);

        [TestMethod]
        public void ClassHasTwoSourceAnchors() => Assert.AreEqual(2, (importer.Types.Named("SampleProject.Basic.MyPartialClass").sourceAnchor as MultipleFileAnchor).AllFiles.Count);

        [TestMethod]
        public void ClassHasAllLOC() => Assert.AreEqual(16, importer.Types.Named("SampleProject.Basic.MyPartialClass").numberOfLinesOfCode);
    }
}
