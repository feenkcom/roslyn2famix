using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest
{
    [TestClass]
    public class BinarySuperclassesTest : SampleSystemLoader
    {
        [TestMethod]
        public void LinkedListIsIngested() => Assert.IsNotNull(importer.Types.Named("System.Collections.Generic.LinkedList<T>"));

        [TestMethod]
        public void BinaryClassHasMethods() =>
          Assert.AreEqual(33, importer.Types.Named("System.Collections.Generic.LinkedList<T>").Methods.Count);

    }
}
