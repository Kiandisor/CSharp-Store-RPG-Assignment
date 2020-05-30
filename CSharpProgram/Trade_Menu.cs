using System;
using System.Collections.Generic;

namespace Store_RPG_Assignment {
    /// <summary>
    /// Functions and variables for the trading menu
    /// </summary>
    public class Trading_Menu {
        /// <summary>
        /// Int for the amount to add or subtract from the inventory
        /// </summary>
        public int ChangeAmount = 0;

        /// <summary>
        /// float to hold the cost of the item selected
        /// </summary>
        public float CostOfItem {get;set;} = 0;

        /// <summary>
        /// Returns the user choice for the trade menu
        /// </summary>
        /// <returns></returns>
        public string ReturnTradeUserChoice {get;set;} = "";

        /// <summary>
        /// Returns the user choice for which inventory to trade to menu
        /// </summary>
        /// <returns></returns>
        public bool TradeToChoice {get;set;} = true;

        /// <summary>
        /// Return amount to buy
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int ReturnItemAmount
        {
            get {return ChangeAmount;}
        }

        /// <summary>
        /// Sets the item choice for what the user wants to trade
        /// </summary>
        /// <returns></returns>
        public string GetItemChoice(List<Inventory_Item> Inventory)
        {
            Console.WriteLine("Welcome to the store!");
            Console.WriteLine("What would you like to trade?");

            //Print our each of the items name in the store inventory
            foreach (var Item in Inventory) {
                Console.WriteLine($"- {Item.Item_Name}");
            }

            Console.WriteLine("- Main Menu (menu)");

            //Gets the user input makes it 
            ReturnTradeUserChoice=Console.ReadLine().ToLower();

            //Check each item in the store
            foreach (var CheckName in Inventory) {
                //If the player input is menu then return that value
                if (ReturnTradeUserChoice=="menu") {

                    return ReturnTradeUserChoice;
                }
                //If the name of the item is the same as one in the inventory
                if (CheckName.Item_Name==ReturnTradeUserChoice) {

                    //Set CostOfItem to the price of the item in the inventory
                    CostOfItem=CheckName.Item_Cost;

                    //Return the item name
                    return ReturnTradeUserChoice;
                }
            }
            //If the player input is not valid ask for another one
            Console.Clear();
            Console.WriteLine("Please enter a valid item.");
            GetItemChoice(Inventory);

            return ReturnTradeUserChoice;
        }

        /// <summary>
        /// Get the amount of the item you want
        /// </summary>
        /// <returns></returns>
        public int GetAmount()
        {
            Console.WriteLine($"How many {ReturnTradeUserChoice}s would you like to trade?");

            //Gets the users amount
            string sChangeAmount = Console.ReadLine();

            //Bool to check if the users input can be parsed to a int
            bool CheckParse = int.TryParse(sChangeAmount,out ChangeAmount);

            //If it can be parsed, set the ChangeAmount to the value of the string
            if (CheckParse==true) {
                //Parse the string to int
                ChangeAmount=int.Parse(sChangeAmount);
                //Checks if the number is above 0
                if (ChangeAmount>=0) {
                    return ChangeAmount;
                }
                //Asks for another input if the number is below 0
                else {
                    Console.WriteLine("Amount cannot be a number under 0.");
                    return GetAmount();
                }
            }
            //If not keep running the function until the user enters a valid input
            else {

                Console.WriteLine("That was not a valid input. Please enter a number.");
                return GetAmount();
            }
        }

        /// <summary>
        /// Get where you want to take items from
        /// </summary>
        /// <returns></returns>
        public bool GetTo_Or_From()
        {
            Console.WriteLine("Would you like to trade to the store or from it?");
            Console.WriteLine("- To the store (to)");
            Console.WriteLine("- From the store (from)");

            //String to hold the users choice
            string STradeToChoice=Console.ReadLine().ToLower();

            //Switch statement to decide if the input is valid or not. Will set the bool for if the player is trading to the store or from it
            switch (STradeToChoice) {
                //Player is trading to the store
                case "to":
                    return TradeToChoice=false;
                //Player is trading from the store
                case "from":
                    return TradeToChoice=true;
                //The input was not valid and will prompt the user for another input
                default:
                    Console.Clear();
                    Console.WriteLine("Please enter a valid input");
                    GetTo_Or_From();
                    break;
            }
            return TradeToChoice;
        }

        /// <summary>
        /// Prints out that the item is out of stock
        /// </summary>
        public void OutOfStock(bool PlayerOrStore)
        {
            //If the player wants to trade from the store
            if (PlayerOrStore==true) {
                Console.Clear();
                Console.WriteLine($"The {ReturnTradeUserChoice} is currently out of stock.");
                Console.WriteLine();
            }
            //If the player wants to trade to the store
            else {
                Console.Clear();
                Console.WriteLine($"You don't have any {ReturnTradeUserChoice}s.");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Tells the user they have no money to purchase anything
        /// </summary>
        public void NoCurrency() {
            Console.WriteLine("You don't have any money to spend.");
        }
        
        /// <summary>
        /// Prints out that there wasn't enough of the item in stock and changes the amount you wanted to the amount left in stock.
        /// </summary>
        /// <param name="AmountInInventory"></param>
        /// <param name="amount"></param>
        /// <param name="PlayerOrStore"></param>
        public int TradedRemainder(ref int AmountInInventory,int amount,bool PlayerOrStore,ref float PlayerCurrency)
        {
            //If the player wants to trade from the store
            if (PlayerOrStore==true) {
                if () { }
                Console.WriteLine($"You wanted to trade {amount} {ReturnTradeUserChoice} but the shop only had {AmountInInventory}.");
                Console.WriteLine($"You ended up trading for the rest of their stock instead ({AmountInInventory}).");

                Console.WriteLine();

                //Sets the amount to be traded to the amount in the store inventory
                amount=AmountInInventory;

                //Sets the Cost of the item equal to the amount x the cost 
                CostOfItem*=amount;

                //Takes the remainder of the currency from the player
                PlayerCurrency-=CostOfItem;

                //Takes the remainder of the items in the store inventory
                return AmountInInventory-=amount;
            }
            //If the player wants to trade to the store
            else {
                Console.WriteLine($"You wanted to trade {amount} {ReturnTradeUserChoice} to the shop but only had {AmountInInventory}.");
                Console.WriteLine($"You ended up trading the rest of the {ReturnTradeUserChoice}(s) you had.");

                Console.WriteLine();

                //Sets the amount to be traded to the amount in the Player inventory
                amount=AmountInInventory;

                //Sets the Cost of the item equal to the amount x the cost 
                CostOfItem*=amount;

                //Takes the remainder of the items in the player inventory
                AmountInInventory-=amount;

                //Adds the remainder of the currency from the player
                PlayerCurrency+=CostOfItem;

                //Takes the remainder of the items in the player inventory
                return AmountInInventory-=amount;
            }
        }

        /// <summary>
        /// Purchases items from the store
        /// </summary>
        /// <param name="AmountInInventory"></param>
        /// <param name="amount"></param>
        /// <param name="PlayerOrStore"></param>
        public int PurchaseItem(ref int AmountInInventory,int amount,bool PlayerOrStore,ref float PlayerCurrency)
        {
            //If the player trades from the store
            if (PlayerOrStore==true) {
                    //Calculates the total cost
                    CostOfItem*=amount;

                    //Takes the amount of money from the player
                    PlayerCurrency-=CostOfItem;

                    //Takes the amount of items from the store
                    Console.WriteLine($"You have traded for {amount} {ReturnTradeUserChoice}(s).");
                    return AmountInInventory-=amount;
            }
            //If the player trades to the store
            else {

                //Takes the amount of items from the player
                AmountInInventory-=amount;
                Console.WriteLine($"You have traded back {amount} {ReturnTradeUserChoice}(s).");

                //Calculates the total cost
                CostOfItem*=amount;

                //Adds the amount of money to the player
                PlayerCurrency+=CostOfItem;

                //Takes the amount of items from the player
                Console.WriteLine($"You have traded back {amount} {ReturnTradeUserChoice}(s).");
                return AmountInInventory-=amount;
            }
        }

        /// <summary>
        /// Add and subtract items from the lists
        /// </summary>
        /// <param name="PlayerChange"></param>
        /// <param name="StoreChange"></param>
        /// <param name="ChangeAmount"></param>
        /// <param name="To_Or_From"></param>
        public void ChangeInventory(ref List<Inventory_Item> PlayerChange,ref List<Inventory_Item> StoreChange,string ItemChoice,int Amount,bool To_Or_From,ref float PlayerCurrency)
        {
            //If the player is trading from the store
            if (To_Or_From==true) {
                //Check each item in the store inventory
                foreach (var StoreValueChange in StoreChange) {
                    //If the item is not in the inventory then keep looping 
                    if (ItemChoice!=StoreValueChange.Item_Name) {
                        continue;
                    }
                    //If there are no items then it is out of stock
                    if (StoreValueChange.Item_Amount==0) {
                        OutOfStock(To_Or_From);
                        break;
                    }
                    //If the player currency is less than 0
                    if (PlayerCurrency<0) {
                        NoCurrency();
                        break;
                    }
                    //If the amount wanted is greater than the amount the inventory has trade for the remainder
                    if ((ChangeAmount>StoreValueChange.Item_Amount)&&(StoreValueChange.Item_Amount!=0)||
                        (PlayerCurrency<ChangeAmount)) {
                        TradedRemainder(ref StoreValueChange.Item_Amount,Amount,To_Or_From,ref PlayerCurrency);
                        break;
                    }
                    //If the user choice is the in the list, trade the item
                    else {
                        PurchaseItem(ref StoreValueChange.Item_Amount,Amount,To_Or_From,ref PlayerCurrency);
                    }
                }
                //Check each item in the inventory until the user choice is the same as the inventory item
                foreach (var ItemValueChange in PlayerChange) {
                    //Add the change amount to the user inventory
                    if (ReturnTradeUserChoice==ItemValueChange.Item_Name) {
                        ItemValueChange.Item_Amount+=ChangeAmount;
                    }
                }
            }
            //If the player is trading to the store
            else {
                //Check each item in the store inventory
                foreach (var PlayerValueChange in PlayerChange) {
                    //If the item is not in the inventory then keep looping 
                    if (ItemChoice!=PlayerValueChange.Item_Name) {
                        continue;
                    }
                    //If there are no items then it is out of stock
                    if (PlayerValueChange.Item_Amount==0) {
                        OutOfStock(To_Or_From);
                        break;
                    }
                    //If the amount wanted is greater than the amount the inventory has trade for the remainder
                    if ((ChangeAmount>PlayerValueChange.Item_Amount)&&(PlayerValueChange.Item_Amount!=0)) {
                        TradedRemainder(ref PlayerValueChange.Item_Amount,Amount,To_Or_From,ref PlayerCurrency);
                        break;
                    }
                    //If the user choice is the in the list, trade the item
                    else {
                        PurchaseItem(ref PlayerValueChange.Item_Amount,Amount,To_Or_From,ref PlayerCurrency);
                    }
                }
                //Check each item in the inventory until the user choice is the same as the inventory item
                foreach (var ItemValueChange in StoreChange) {
                    //Add the change amount to the user inventory
                    if (ReturnTradeUserChoice==ItemValueChange.Item_Name) {
                        ItemValueChange.Item_Amount+=ChangeAmount;
                    }
                }
            }
        }
    }
}