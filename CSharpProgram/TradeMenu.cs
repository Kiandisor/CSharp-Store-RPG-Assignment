using System;
using System.Collections.Generic;

namespace Store_RPG_Assignment {
    /// <summary>
    /// Functions and variables for the trading menu
    /// </summary>
    class Trading_Menu {

        //String for the user choice for the items
        string TradeUserChoice = "";

        //String for the user choice to which inventory to trade to
        string TradeMenuChoice = "";

        //Int for the amount to add or subtract from the inventory
        int ChangeAmount = 0;

        /// <summary>
        /// Prints the menu for selecting which inventory you want to take from
        /// </summary>
        public void ShowSelectInventoryMenu() {
            Console.WriteLine("Welcome to the store!");
            Console.WriteLine("Would you like to trade to the store or from it?");
            Console.WriteLine("- To the store (to)");
            Console.WriteLine("- From the store (from)");
            Console.WriteLine("- Back to menu (menu)");
            
            TradeMenuChoice = Console.ReadLine().ToLower();
        }

        /// <summary>
        /// Print the trade menu
        /// </summary>
        public void ShowTradeMenu() {
            Console.WriteLine("Welcome to the store!");
            Console.WriteLine($"What would you like to trade {TradeMenuChoice} the store?");
            Console.WriteLine("- Art Book");
            Console.WriteLine("- C# Book");
            Console.WriteLine("- Medic Book");
            Console.WriteLine("- Note Book");
            Console.WriteLine("- Return to menu (menu)");

            TradeUserChoice = Console.ReadLine().ToLower();
        }

        /// <summary>
        /// Returns the user choice for the trade menu
        /// </summary>
        /// <returns></returns>
        public string ReturnTradeUserChoice() {
            
            return TradeUserChoice;

        }

        /// <summary>
        /// Returns the user choice for which inventory to trade to menu
        /// </summary>
        /// <returns></returns>
        public string ReturnTradeMenuChoice() {

            return TradeMenuChoice;

        }

        /// <summary>
        /// Return amount to buy
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int TradeItemAmount(int amount) {

            return amount;
        
        }

        /// <summary>
        /// Get the amount of the item you want
        /// </summary>
        /// <returns></returns>
        public int GetAmount() {

            Console.WriteLine($"How many {TradeUserChoice}s would you like to trade?");
            
            //Gets the users amount
            string sChangeAmount = Console.ReadLine();

            //Bool to check if the users input can be parsed to a int
            bool CheckParse = int.TryParse(sChangeAmount, out ChangeAmount);
            //If it can be parsed, set the ChangeAmount to the value of the string
            if (CheckParse == true) {

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
        /// Add and subtract items from the lists
        /// </summary>
        /// <param name="PlayerChange"></param>
        /// <param name="StoreChange"></param>
        public void ChangeShopInventory(List<Inventory_Item> PlayerChange, List<Inventory_Item> StoreChange, int ChangeAmount) {

            //Check each item in the store inventory
            foreach (var StoreValueChange in StoreChange) {

                //If the user choice is the in the list, trade the item
                if (TradeUserChoice == StoreValueChange.Item_Name) {

                    //Check if the item in stock is not avalible
                    //If it is, buy the item
                    if (StoreValueChange.Item_Amount != 0) {
                        if (ChangeAmount <= StoreValueChange.Item_Amount) {
                            StoreValueChange.Item_Amount -= ChangeAmount;
                            Console.WriteLine($"You have traded for {ChangeAmount} {TradeUserChoice}");
                        }

                        //If you trade more than the shop has but the shop has the item, take the rest of the amount and 
                        else {

                            Console.WriteLine($"You wanted to trade {ChangeAmount} {TradeUserChoice} but the shop only had {StoreValueChange.Item_Amount}.");

                            ChangeAmount = StoreValueChange.Item_Amount;

                            Console.WriteLine($"You ended up trading for the rest of their stock instead ({ChangeAmount}).");

                            StoreValueChange.Item_Amount -= StoreValueChange.Item_Amount;

                            Console.WriteLine();
                        }
                    }

                    //Tell the user the item is out of stock if there is none left
                    else {
                        Console.Clear();
                        Console.WriteLine($"The {TradeUserChoice} is currently out of stock.");
                        Console.WriteLine();
                    }
                }
            }

            //Check each item in the inventory until the user choice is the same as the inventory item
            foreach (var ItemValueChange in PlayerChange) {

                //Add the change amount to the user inventory
                if (TradeUserChoice == ItemValueChange.Item_Name) {
                    ItemValueChange.Item_Amount += ChangeAmount;
                }
            }
        }

        /// <summary>
        /// Add and subtract items from the lists
        /// </summary>
        /// <param name="PlayerChange"></param>
        /// <param name="StoreChange"></param>
        public void ChangePlayerInventory(List<Inventory_Item> PlayerChange, List<Inventory_Item> StoreChange, int ChangeAmount) {

            //Check each item in the store inventory
            foreach (var PlayerValueChange in PlayerChange) {

                //If the user choice is the in the list, trade the item
                if (TradeUserChoice == PlayerValueChange.Item_Name) {

                    //Check if the item in stock is not avalible
                    //If it is, buy the item
                    if (PlayerValueChange.Item_Amount != 0) {
                        if (ChangeAmount <= PlayerValueChange.Item_Amount) {
                            PlayerValueChange.Item_Amount -= ChangeAmount;
                            Console.WriteLine($"You traded to the shop {ChangeAmount} {TradeUserChoice}(s)");
                        }

                        //If you trade more than the shop has but the shop has the item, take the rest of the amount and 
                        else {

                            Console.WriteLine($"You wanted to trade {ChangeAmount} {TradeUserChoice} to the shop but only had {PlayerValueChange.Item_Amount}.");

                            ChangeAmount = PlayerValueChange.Item_Amount;

                            Console.WriteLine($"You ended up trading for the rest the {TradeUserChoice}(s) instead ({ChangeAmount}).");

                            PlayerValueChange.Item_Amount -= PlayerValueChange.Item_Amount;

                            Console.WriteLine();
                        }
                    }

                    //Tell the user the item is out of stock if there is none left
                    else {
                        Console.Clear();
                        Console.WriteLine($"You don't have any {TradeUserChoice} in your inventory.");
                        Console.WriteLine();
                    }
                }
            }

            //Check each item in the inventory until the user choice is the same as the inventory item
            foreach (var StoreValueChange in StoreChange) {

                //Add the change amount to the user inventory
                if (TradeUserChoice == StoreValueChange.Item_Name) {
                    StoreValueChange.Item_Amount += ChangeAmount;
                }
            }
        }

        }
    }