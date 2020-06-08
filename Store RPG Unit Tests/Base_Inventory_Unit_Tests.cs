using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store_RPG_Assignment;
using System.ComponentModel;

namespace Store_RPG_Unit_Tests {
    [TestClass]
    public class Base_Inventory_Unit_Tests {
        Inventory_Item TestItem = new Inventory_Item("Test",10,10.5f,10);

        [TestMethod]
        public void TestItemProperties()
        {
            Assert.AreEqual(TestItem.Item_Name,"Test");
            Assert.AreEqual(TestItem.Item_Amount,10);
            Assert.AreEqual(TestItem.Item_Cost,10.5f);
            Assert.AreEqual(TestItem.Item_Pages,10);
        }

        [TestMethod]
        public void TestItemPropertiesToString()
        {
            string name = TestItem.ReturnNameAsString;
            string amount = TestItem.ReturnAmountAsString;
            string cost = TestItem.ReturnCostAsString;
            string pages = TestItem.ReturnPagesAsString;

            Assert.AreEqual(name,"Test");
            Assert.AreEqual(amount,"10");
            Assert.AreEqual(cost,"10.5");
            Assert.AreEqual(pages,"10");
        }
    }
}
