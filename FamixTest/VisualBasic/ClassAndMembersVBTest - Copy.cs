using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FamixTest.VisualBasic
{
    [TestClass]
    public class ClassAndMembersVBTest : SampleSystemLoader
    {
        [TestMethod]
        public void VBClassWasIngested() => Assert.IsNotNull(importer.Types.Named("VBSampleProject.ClassAndMembers.ConvertPostCode"));

        [TestMethod]
        public void VBClassMembersWereIngested()
        {
            Assert.AreEqual(importer.Types.Named("VBSampleProject.ClassAndMembers.ConvertPostCode").Methods.Count, 1);
            Assert.IsNotNull(importer.Methods.Named("VBSampleProject.ClassAndMembers.ConvertPostCode.DoConvert(String)"));
        }
    }
}
