using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest
{
    [TestClass]
    public class SubClassTest : SampleSystemLoader
    {
        [TestMethod]
        public void SimpleInheritanceTest()
        {
            Assert.AreEqual(1, importer.Types.Named(".SampleProject.Basic.SubClass").SuperInheritances.Count);
            Assert.AreEqual(1, importer.Types.Named(".SampleProject.Basic.BaseClass").SubInheritances.Count);
        }
    }
}
