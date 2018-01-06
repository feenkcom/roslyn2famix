using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest
{
    [TestClass]
    public class GenericsTest : SampleSystemLoader
    {
        [TestMethod]
        public void GenericsTypeIsIngested()
            => Assert.IsNotNull(importer.Types.Named("SampleProject.Basic.Generics<T>"));

        [TestMethod]
        public void GenericsTypeIsCorrectType() => Assert.IsInstanceOfType(importer.Types.Named("SampleProject.Basic.Generics<T>"), typeof(FAMIX.ParameterizableClass));


    }
}
