using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FamixTest
{
    [TestClass]
    public class ExceptionsTest : SampleSystemLoader
    {
        [TestMethod]
        public void CaughtExceptions()
        {
            var allCaughtExceptions = importer.AllElementsOfType<FAMIX.CaughtException>();
            Assert.AreEqual("Method", allCaughtExceptions.First<FAMIX.CaughtException>().definingMethod.name);
            Assert.AreEqual("Exceptions", allCaughtExceptions.First<FAMIX.CaughtException>().exceptionClass.name);
        }
    }
  
}
