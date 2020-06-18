using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FamixTest.VisualBasic
{
    [TestClass]
    public class InheritanceVBTest : SampleSystemLoader
    {
        [TestMethod]
        public void VBClassesWereIngested()
        {
            Assert.IsNotNull(importer.Types.Named("VBSampleProject.Inheritance.Payroll"));
            Assert.IsNotNull(importer.Types.Named("VBSampleProject.Inheritance.BonusPayroll"));
        }

        [TestMethod]
        public void VBClassInheritance()
        {
            Assert.AreEqual(importer.Types.Named("VBSampleProject.Inheritance.Payroll").SubInheritances.Count, 1);
            Assert.AreEqual(importer.Types.Named("VBSampleProject.Inheritance.BonusPayroll").SuperInheritances.Count, 1);
        }
    }
}
