using System;
using System.Linq;
using Humanizer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest.VisualBasic
{
    [TestClass]
    public class MethodCallsVBTest : SampleSystemLoader
    {
        [TestMethod]
        public void IntraModuleCallCount() => Assert.AreEqual(2, importer.Methods.Named("VBSampleProject.MethodCalls.Caller()").OutgoingInvocations.Count);

        [TestMethod]
        public void IntraModuleCallName() => Assert.IsNotNull( importer.Methods.Named("VBSampleProject.MethodCalls.Caller()").OutgoingInvocations.Find(o => o.Candidates.FindIndex(c => c.name == "Callee") >= 0));

        [TestMethod]
        public void InterModuleCallName() => Assert.IsNotNull(importer.Methods.Named("VBSampleProject.MethodCalls.Caller()").OutgoingInvocations.Find(o => o.Candidates.FindIndex (c => c.name == "DisplayAdd") >= 0 ));
    }
}
