using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store_RPG_Assignment;
using System.ComponentModel;

namespace Store_RPG_Unit_Tests {
    [TestClass]
    public class Trade_Menu_Unit_Tests {

        Trading_Menu TestTradeMenu = new Trading_Menu();

        /// <summary>
        /// Test method for the purchace item function
        /// </summary>
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

        /// <summary>
        /// Test method for the trade remainder function
        /// </summary>
        [TestMethod]
        public void TestTradeRemainder()
        {
            //Variables for first assert
            TestTradeMenu.CostOfItem=10.2f;
            TestTradeMenu.ChangeAmount=3;
            TestTradeMenu.TradeToChoice=true;
            float currency = 3.4f;
            int InventoryAmount = 2;

            //The this will pass because you cant trade anything if the total cost of it is above the players money
            Assert.AreEqual(TestTradeMenu.TradedRemainder(ref InventoryAmount,TestTradeMenu.ChangeAmount,TestTradeMenu.TradeToChoice,ref currency),0);

            //Variables for second assert
            TestTradeMenu.CostOfItem=3.2f;
            TestTradeMenu.ChangeAmount=3;
            TestTradeMenu.TradeToChoice=true;
            currency=4.4f;
            InventoryAmount=2;

            //The this will pass because total cost of the items is below the players money amount
            Assert.AreEqual(TestTradeMenu.TradedRemainder(ref InventoryAmount,TestTradeMenu.ChangeAmount,TestTradeMenu.TradeToChoice,ref currency),0);

            //Variables for third assert
            TestTradeMenu.CostOfItem=3.2f;
            TestTradeMenu.ChangeAmount=3;
            TestTradeMenu.TradeToChoice=true;
            currency=35.4f;
            InventoryAmount=2;

            //The this will pass because total cost of the items is below the players money amount
            Assert.AreEqual(TestTradeMenu.TradedRemainder(ref InventoryAmount,TestTradeMenu.ChangeAmount,TestTradeMenu.TradeToChoice,ref currency),0);
        }

        /// <summary>
        /// Test method for the get to or from function
        /// </summary>
        [TestMethod]
        public void TestGetTo_Or_From()
        {
            //Variable for assert
            string STradeToChoice = "to";

            switch (STradeToChoice) {
                case "to":
                    TestTradeMenu.TradeToChoice=true;
                    Assert.AreEqual(TestTradeMenu.TradeToChoice,true);
                    break;
                case "from":
                    TestTradeMenu.TradeToChoice=false;
                    Assert.AreEqual(TestTradeMenu.TradeToChoice,false);
                    break;
            }
        }
    }
}
