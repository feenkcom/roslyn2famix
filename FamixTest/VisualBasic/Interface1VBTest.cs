using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest.VisualBasic
{
    [TestClass]
    public class Interface1VBTest : SampleSystemLoader
    {
        [TestMethod]
        public void VBInterfaceWasIngested() => Assert.IsNotNull(importer.Types.Named("VBSampleProject.Interface1"));
    }
}
