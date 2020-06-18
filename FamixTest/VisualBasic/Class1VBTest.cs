using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest.VisualBasic
{
    [TestClass]
    public class Class1VBTest : SampleSystemLoader
    {
        [TestMethod]
        public void VBClassWasIngested() => Assert.IsNotNull(importer.Types.Named("VBSampleProject.Class1"));

        [TestMethod]
        public void VBClassSuperClassObject() => Assert.IsNotNull(importer.Types.Named("VBSampleProject.Class1").SuperInheritances.Find(i => i.superclass.name == "Object"));
    }
}
