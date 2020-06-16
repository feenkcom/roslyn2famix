using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest.VisualBasic
{
    [TestClass]
    public class MethodCallsVBTest : SampleSystemLoader
    {
        [TestMethod]
        public void IntraModuleCallCount() => Assert.AreEqual(1, importer.Methods.Named("VBSampleProject.MethodCalls.Caller()").OutgoingInvocations.Count);

        [TestMethod]
        public void IntraModuleCallName() => Assert.AreEqual("Callee", importer.Methods.Named("VBSampleProject.MethodCalls.Caller()").OutgoingInvocations.First<FAMIX.Invocation>().Candidates.First<FAMIX.BehaviouralEntity>().name);
    }
}
