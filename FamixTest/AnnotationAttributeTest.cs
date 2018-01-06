using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest
{
    [TestClass]
    public class AnnotationAttributeTest : SampleSystemLoader
    {
        [TestMethod]
        public void IngestedAnnotationTypes() => 
            Assert.IsNotNull(importer.Types.Named("SampleProject.Basic.AnnotationAttribute"));

        [TestMethod]
        public void AnnotationTypeIsNotSimpleClass() => 
            Assert.IsTrue(importer.Types.Named("SampleProject.Basic.AnnotationAttribute") is FAMIX.AnnotationType);

        [TestMethod]
        public void AnotationTypeHasAttributes()
        {
            Assert.AreEqual(3, importer.Types.Named("SampleProject.Basic.AnnotationAttribute").Attributes.Count);
            Assert.IsTrue(importer.Types.Named("SampleProject.Basic.AnnotationAttribute").Attributes.Find(attr =>
            attr.name.Equals("FirstString")) is FAMIX.AnnotationTypeAttribute);
        }
    }
}
