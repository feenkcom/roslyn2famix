using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest.VisualBasic
{
    [TestClass]
    public class Module1VBTest : SampleSystemLoader
    {
        [TestMethod]
        public void VBModuleWasIngested() => Assert.IsNotNull(importer.Types.Named("VBSampleProject.Module1"));
    }
}
