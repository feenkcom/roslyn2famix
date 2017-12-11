using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest
{
    [TestClass]
    public class AttributeTest : SampleSystemLoader
    {
        [TestMethod]
        public void SingleAttributeWasIngested() =>
            Assert.IsNotNull(importer.Attributes.Named(".SampleProject.Basic.Attribute.i"));
    }
}
