using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store_RPG_Assignment;
using System.ComponentModel;

namespace Store_RPG_Unit_Tests {
    [TestClass]
    public class Super_User_Unit_Tests {
        Super_User TestSuperUser = new Super_User("Book",3,13.4f,20);

        [TestMethod]
        public void TestSetPages()
        {   
            Assert.AreEqual(TestSuperUser.CustomPages,20);
        }

        [TestMethod]
        public void TestSetName()
        {
            Assert.AreEqual(TestSuperUser.CustomName,"Book");
        }

        [TestMethod]
        public void TestSetCost()
        {
            Assert.AreEqual(TestSuperUser.CustomCost, 13.4f);
        }

        [TestMethod]
        public void TestSetAmount()
        {
            Assert.AreEqual(TestSuperUser.CustomAmount,3);
        }
    }
}
