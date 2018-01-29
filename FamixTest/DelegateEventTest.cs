using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest
{
    [TestClass]
    public class DelegateEventTest : SampleSystemLoader
    {
        [TestMethod]
        public void DelegateIngested() => Assert.IsNotNull(importer.Types.Named("SecondChangeEvent.Clock.SecondChangeHandler"));

        [TestMethod]
        public void EventIngested() => Assert.IsNotNull(importer.Attributes.Named("SecondChangeEvent.Clock.SecondChange"));

        [TestMethod]
        public void EventAsPropertyIngested() => Assert.IsNotNull(importer.Attributes.Named("SecondChangeEvent.Clock.ThirdChange"));

    }
}
