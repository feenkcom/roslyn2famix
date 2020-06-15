using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest
{
    [TestClass]
    public class CallsTest : SampleSystemLoader
    {
        [TestMethod]
        public void TestStandardCall() =>
            Assert.AreEqual(2, importer.Methods.Named("SampleProject.Basic.StandardCaller.CallerMethod()").OutgoingInvocations.Count);


        [TestMethod]
        public void MethodWasIngested() =>
            Assert.IsNotNull(importer.Methods.Named("SampleProject.Basic.Called.CalledMethod()"));

        [TestMethod]
        public void MethodBelongsToClass() =>
            Assert.AreEqual(1, importer.Types.Named("SampleProject.Basic.Called").Methods.Count);

    }
}
