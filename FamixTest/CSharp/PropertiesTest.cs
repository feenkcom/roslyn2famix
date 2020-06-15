using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest
{
    [TestClass]
    public class PropertiesTest : SampleSystemLoader
    {
        [TestMethod]
        public void TestPropertyHasSetter()
        {
            CSharp.CSharpProperty pro = importer.Attributes.Named("SampleProject.Basic.Properties.Value") as CSharp.CSharpProperty;
            Assert.IsNotNull(pro.setter);
            Assert.AreSame(pro.setter.OutgoingInvocations[0].Candidates[0],(importer.Methods.Named("SampleProject.Basic.Properties.Method()")));
        }
    }
}
