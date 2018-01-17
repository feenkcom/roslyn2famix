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
            Assert.AreEqual(1, importer.Types.Named("SampleProject.Basic.SubClass").SuperInheritances.Count);
            Assert.AreEqual(1, importer.Types.Named("SampleProject.Basic.BaseClass").SubInheritances.Count);
        }

        public void SingleInterfaceImplementationTest()
        {
            //Object and the interface
            Assert.AreEqual(2, importer.Types.Named("SampleProject.Basic.BaseClass").SuperInheritances.Count);
            Assert.IsNotNull(importer.Types.Named("System.IDisposable"));
            Assert.IsTrue(importer.Types.Named("System.IDisposable") is FAMIX.Class);
        } 
    }   
}
