using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest.VisualBasic
{
    [TestClass]
    public class SubroutineVBTest : SampleSystemLoader
    {
        [TestMethod]
        public void VBSubroutineWasIngested() => Assert.IsNotNull(importer.Methods.Named("VBSampleProject.Subroutine.DisplayAdd(Int32,Int32)"));
    }
}
