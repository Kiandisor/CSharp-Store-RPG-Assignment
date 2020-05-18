using System;
using System.Collections.Generic;

namespace Store_RPG_Assignment {

    /// <summary>
    /// Functions and variables for the trading menu
    /// </summary>
    class Trading_Menu {

        /// <summary>
        /// Int for the amount to add or subtract from the inventory
        /// </summary>
        int ChangeAmount = 0;

        /// <summary>
        /// float to hold the cost of the item selected
        /// </summary>
        float CostOfItem = 0;
        
        /// <summary>
        /// Returns the user choice for the trade menu
        /// </summary>
        /// <returns></returns>
        public string ReturnTradeUserChoice { get; private set; } = "";

        /// <summary>
        /// Returns the user choice for which inventory to trade to menu
        /// </summary>
        /// <returns></returns>
        public bool ReturnTradeToChoice { get; private set; } = true;

        /// <summary>
        /// Return amount to buy
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int ReturnItemAmount {
            get {
                return ChangeAmount;
            }
        }

        /// <summary>
        /// Prints the menu for selecting which inventory you want to take from
        /// </summary>
        public void ShowTradeMenu(List<Inventory_Item> Store) {

            GetItemChoice(Store);

            GetTo_Or_From();

            GetAmount();
        }

        /// <summary>
        /// Sets the item choice for what the user wants to trade
        /// </summary>
        /// <returns></returns>
        public string GetItemChoice(List<Inventory_Item> Store) {

            Console.WriteLine("Welcome to the store!");
            Console.WriteLine("What would you like to trade?");
            

            foreach (var Item in Store) {

                Console.WriteLine($"- {Item.Item_Name}");
            
            }

            ReturnTradeUserChoice = Console.ReadLine().ToLower();

            foreach (var CheckName in Store) {

                if (CheckName.Item_Name == ReturnTradeUserChoice) {

                    CheckName.Item_Cost = CostOfItem;   

                    return ReturnTradeUserChoice;
                }
            }

            Console.Clear();
            Console.WriteLine("Please enter a valid item.");
            GetItemChoice(Store);

            return ReturnTradeUserChoice;
        }

        /// <summary>
        /// Get the amount of the item you want
        /// </summary>
        /// <returns></returns>
        public int GetAmount() {

            Console.WriteLine($"How many {ReturnTradeUserChoice}s would you like to trade?");

            //Gets the users amount
            string sChangeAmount = Console.ReadLine();

            //Bool to check if the users input can be parsed to a int
            bool CheckParse = int.TryParse(sChangeAmount, out ChangeAmount);

            //If it can be parsed, set the ChangeAmount to the value of the string
            if (CheckParse == true) {

                //Parse the string to int
                ChangeAmount = int.Parse(sChangeAmount);

                return ChangeAmount;
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
        public bool GetTo_Or_From() {

            Console.WriteLine("Would you like to trade to the store or from it?");
            Console.WriteLine("- To the store (to)");
            Console.WriteLine("- From the store (from)");

            //String to hold the users choice
            string TradeToChoice = "";

            TradeToChoice = Console.ReadLine().ToLower();

            //Switch statement to decide if the input is valid or not. Will set the bool for if the player is trading to the store or from it
            switch (TradeToChoice) {
                //Player is trading to the store
                case "to":
                    ReturnTradeToChoice = false;
                    break;
                //Player is trading from the store
                case "from":
                    ReturnTradeToChoice = true;
                    break;
                //The input was not valid and will prompt the user for another input
                default:
                    Console.Clear();
                    Console.WriteLine("Please enter a valid input");
                    GetTo_Or_From();
                    break;
            }

            return ReturnTradeToChoice;
        }

        /// <summary>
        /// Prints out that the item is out of stock
        /// </summary>
        public void OutOfStock(bool PlayerOrStore) {
            
            //If the player wants to trade from the store
            if (PlayerOrStore == true) {
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
        /// Prints out that there wasn't enough of the item in stock and changes the amount you wanted to the amount left in stock.
        /// </summary>
        /// <param name="AmountInInventory"></param>
        /// <param name="amount"></param>
        /// <param name="PlayerOrStore"></param>
        public void TradedRemainder(ref int AmountInInventory, ref int amount, bool PlayerOrStore, float PlayerCurrency) {

            //If the player wants to trade from the store
            if (PlayerOrStore == true) {
                Console.WriteLine($"You wanted to trade {amount} {ReturnTradeUserChoice} but the shop only had {AmountInInventory}.");
                Console.WriteLine($"You ended up trading for the rest of their stock instead ({AmountInInventory}).");

                //Sets the amount to be traded to the amount in the store inventory
                amount = AmountInInventory;

                //Sets the Cost of the item equal to the amount x the cost 
                CostOfItem *= amount;

                //Takes the remainder of the items in the store inventory
                AmountInInventory -= amount;

                //Takes the remainder of the currency from the player
                PlayerCurrency -= CostOfItem;

                Console.WriteLine();
            }

            //If the player wants to trade to the store
            else {
                Console.WriteLine($"You wanted to trade {amount} {ReturnTradeUserChoice} to the shop but only had {AmountInInventory}.");
                Console.WriteLine($"You ended up trading the rest of the {ReturnTradeUserChoice}(s) you had.");

                //Sets the amount to be traded to the amount in the Player inventory
                amount = AmountInInventory;

                //Sets the Cost of the item equal to the amount x the cost 
                CostOfItem *= amount;

                //Takes the remainder of the items in the player inventory
                AmountInInventory -= amount;

                //Adds the remainder of the currency from the player
                PlayerCurrency += CostOfItem;

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Purchases items from the store
        /// </summary>
        /// <param name="AmountInInventory"></param>
        /// <param name="amount"></param>
        /// <param name="PlayerOrStore"></param>
        public void PurchaseItem(ref int AmountInInventory, int amount, bool PlayerOrStore, float PlayerCurrency) {
            if (PlayerOrStore == true) {
                AmountInInventory -= amount;
                Console.WriteLine($"You have traded for {amount} {ReturnTradeUserChoice}(s).");

                Console.WriteLine();
            }

            else {
                AmountInInventory -= amount;
                Console.WriteLine($"You have traded back {amount} {ReturnTradeUserChoice}(s).");

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Add and subtract items from the lists
        /// </summary>
        /// <param name="PlayerChange"></param>
        /// <param name="StoreChange"></param>
        /// <param name="ChangeAmount"></param>
        /// <param name="To_Or_From"></param>
        public void ChangeInventory(ref List<Inventory_Item> PlayerChange, ref List<Inventory_Item> StoreChange, string ItemChoice, int Amount, bool To_Or_From, float PlayerCurrency) {

            if (To_Or_From == true) {
                //Check each item in the store inventory
                foreach (var StoreValueChange in StoreChange) {

                    //If the item is not in the inventory then keep looping 
                    if (ItemChoice != StoreValueChange.Item_Name) {
                        
                        continue;
                    }

                    //If there are no items then it is out of stock
                    if (StoreValueChange.Item_Amount == 0) {

                        OutOfStock(To_Or_From);
                        break;
                    }

                    //If the amount wanted is greater than the amount the inventory has trade for the remainder
                    if (ChangeAmount > StoreValueChange.Item_Amount && StoreValueChange.Item_Amount != 0) {

                        TradedRemainder(ref StoreValueChange.Item_Amount, ref Amount, To_Or_From, PlayerCurrency);
                        break;
                    }

                    //If the user choice is the in the list, trade the item
                    else {
                        PurchaseItem(ref StoreValueChange.Item_Amount, Amount, To_Or_From, PlayerCurrency);
                    }
                }

                //Check each item in the inventory until the user choice is the same as the inventory item
                foreach (var ItemValueChange in PlayerChange) {

                    //Add the change amount to the user inventory
                    if (ReturnTradeUserChoice == ItemValueChange.Item_Name) {
                        ItemValueChange.Item_Amount += ChangeAmount;
                    }
                }
            }

            else {
                //Check each item in the store inventory
                foreach (var PlayerValueChange in PlayerChange) {

                    //If the item is not in the inventory then keep looping 
                    if (ItemChoice != PlayerValueChange.Item_Name) {

                        continue;
                    }

                    //If there are no items then it is out of stock
                    if (PlayerValueChange.Item_Amount == 0) {

                        OutOfStock(To_Or_From);
                        break;
                    }

                    //If the amount wanted is greater than the amount the inventory has trade for the remainder
                    if (ChangeAmount > PlayerValueChange.Item_Amount && PlayerValueChange.Item_Amount != 0) {

                        TradedRemainder(ref PlayerValueChange.Item_Amount, ref Amount, To_Or_From, PlayerCurrency);
                        break;
                    }

                    //If the user choice is the in the list, trade the item
                    else {
                        PurchaseItem(ref PlayerValueChange.Item_Amount, Amount, To_Or_From, PlayerCurrency);
                    }
                }

                //Check each item in the inventory until the user choice is the same as the inventory item
                foreach (var ItemValueChange in StoreChange) {

                    //Add the change amount to the user inventory
                    if (ReturnTradeUserChoice == ItemValueChange.Item_Name) {
                        ItemValueChange.Item_Amount += ChangeAmount;
                    }
                }
            }
        }
    }
}