using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest
{
    [TestClass]
    public class CallsTest : SampleSystemLoader
    {
        [TestMethod]
        public void TestStandardCall() => Assert.AreEqual("bla", metamodel.ExportMSEFile(null));
    }
}
