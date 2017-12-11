using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest
{
    [TestClass]
    public class CallsTest : SampleSystemLoader
    {
        [TestMethod]
        public void TestStandardCall() =>
            Assert.AreEqual(1, importer.Methods.Named(".SampleProject.StandardCaller.CallerMethod()").InvokedMethods.Count);


        [TestMethod]
        public void MethodWasIngested() =>
            Assert.IsNotNull(importer.Methods.Named(".SampleProject.Called.CalledMethod()"));

    }
}
