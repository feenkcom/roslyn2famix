using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest
{
    [TestClass]
    public class ReturnTypeTest : SampleSystemLoader
    {
        [TestMethod]
        public void VoidMethod()
        {
            Assert.AreEqual("Void", importer.Methods.Named("SampleProject.Basic.ReturnType.Method()").declaredType.name);
        }

        [TestMethod]
        public void IntMethod()
        {
            Assert.AreEqual("Int32", importer.Methods.Named("SampleProject.Basic.ReturnType.IntMethod()").declaredType.name, "System.Int");
        }

        [TestMethod]
        public void ReturnMethod()
        {
            Assert.AreEqual("ReturnType", importer.Methods.Named("SampleProject.Basic.ReturnType.ReturnMethod()").declaredType.name);
        }

        [TestMethod]
        public void GenericListMethod()
        {
            Assert.IsInstanceOfType(importer.Methods.Named("SampleProject.Basic.ReturnType.GenericListMethod()").declaredType, typeof(FAMIX.ParameterizedType));
            Assert.AreEqual("List<T>", (importer.Methods.Named("SampleProject.Basic.ReturnType.GenericListMethod()").declaredType as FAMIX.ParameterizedType).parameterizableClass.name);
        }

        [TestMethod]
        public void GenericReturnMethod()
        {
            Assert.IsInstanceOfType(importer.Methods.Named("SampleProject.Basic.ReturnType.GenericReturnTypeMethod()").declaredType, typeof(FAMIX.ParameterizedType));
            Assert.AreEqual("Generics<ReturnType>", importer.Methods.Named("SampleProject.Basic.ReturnType.GenericReturnTypeMethod()").declaredType.name);
            Assert.AreEqual("Generics<T>", (importer.Methods.Named("SampleProject.Basic.ReturnType.GenericReturnTypeMethod()").declaredType as FAMIX.ParameterizedType).parameterizableClass.name);
        }

       
    }
}
