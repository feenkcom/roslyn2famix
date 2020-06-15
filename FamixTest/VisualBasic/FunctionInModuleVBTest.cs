using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest.VisualBasic
{
    [TestClass]
    public class FunctionInModuleVBTest : SampleSystemLoader
    {
        [TestMethod]
        public void VBModuleFunctionWasIngested() => Assert.IsNotNull(importer.Methods.Named("VBSampleProject.FunctionInModule.Hypotenuse(Double,Double)"));
    }
}
