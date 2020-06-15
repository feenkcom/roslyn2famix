using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest
{
    [TestClass]
    public class ExpressionBodyTest : SampleSystemLoader
    {
        [TestMethod]
        public void ConstructorCallsAndAccesses()
        {
            Assert.AreEqual(2, importer.Methods.Named("SampleProject.Basic.ExpressionBody..ctor(String)").Accesses.Count);
            Assert.AreEqual(1, importer.Methods.Named("SampleProject.Basic.ExpressionBody..ctor(String)").OutgoingInvocations.Count);
        }

        [TestMethod]
        public void PropertySetterAccesses() => 
            Assert.AreEqual(2, (importer.Attributes.Named("SampleProject.Basic.ExpressionBody.Name") as CSharp.CSharpProperty).setter.Accesses.Count);
    }
}
