using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest
{
    [TestClass]
    public class EventDelegateClassTest : SampleSystemLoader
    {
        [TestMethod]
        public void EventDelegateClassPlainMethodCallsEvent()
        {
            Assert.AreEqual("MyEvent", 
                importer.Methods.Named("SampleProject.Basic.EventDelegateClass.Trigger()").
                OutgoingInvocations[0].Candidates[0].name);
        }
    }
}
