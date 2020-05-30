using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store_RPG_Assignment;
using System.ComponentModel;

namespace Store_RPG_Unit_Tests {
    [TestClass]
    public class UnitTest1 {

        Trading_Menu TestTradeMenu = new Trading_Menu();


        [TestMethod]
        public void TestPurchaseItem()
        {

            TestTradeMenu.CostOfItem=3.2f;
            TestTradeMenu.ChangeAmount=3;
            TestTradeMenu.TradeToChoice=true;
            float currency = 20f;
            int InventoryAmount = 5;

            Assert.AreEqual(TestTradeMenu.PurchaseItem(ref InventoryAmount,TestTradeMenu.ChangeAmount,TestTradeMenu.TradeToChoice,ref currency),2);
        }

        [TestMethod]
        public void TestTradeRemainder()
        {

            TestTradeMenu.CostOfItem=3.2f;
            TestTradeMenu.ChangeAmount=3;
            TestTradeMenu.TradeToChoice=true;
            float currency = 20f;
            int InventoryAmount = 2;

            Assert.AreEqual(TestTradeMenu.TradedRemainder(ref InventoryAmount,TestTradeMenu.ChangeAmount,TestTradeMenu.TradeToChoice,ref currency),0);
        }
    }
}
