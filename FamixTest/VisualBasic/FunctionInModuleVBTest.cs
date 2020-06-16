using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FamixTest.VisualBasic
{
    [TestClass]
    public class FunctionInModuleVBTest : SampleSystemLoader
    {
        [TestMethod]
        public void VBModuleFunctionWasIngested() => Assert.IsNotNull(importer.Methods.Named("VBSampleProject.FunctionInModule.Hypotenuse(Double,Double)"));


        [TestMethod]
        public void VbFunctionCheckReturnType() => Assert.AreEqual(importer.Methods.Named("VBSampleProject.FunctionInModule.Hypotenuse(Double,Double)").declaredType.name, "Double");

        [TestMethod]
        public void VbFunctionCheckParameters()
        {
            var checkedMethod = importer.Methods.Named("VBSampleProject.FunctionInModule.Hypotenuse(Double,Double)");
            Assert.AreEqual(checkedMethod.Parameters.Count, 2);
            Assert.AreEqual(checkedMethod.Parameters.First().declaredType.name, "Double");
        }

    }
}
