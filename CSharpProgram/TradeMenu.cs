using System;
using System.Collections.Generic;

namespace Store_RPG_Assignment {
    /// <summary>
    /// Functions and variables for the trading menu
    /// </summary>
    class Trading_Menu {

        //String for the user choice
        string TradeUserChoice = "";

        //Int for the amount to add or subtract from the inventory
        int ChangeAmount = 0;

        /// <summary>
        /// Print the trade menu
        /// </summary>
        public void ShowTradeMenu() {
            Console.WriteLine("Welcome to the store!");
            Console.WriteLine("What would you like to trade?");
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

            Console.WriteLine($"How many {TradeUserChoice}s would you like to buy?");
            
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
        public void ChangeInventories(List<Inventory_Item> PlayerChange, List<Inventory_Item> StoreChange, int ChangeAmount) {

            //Check each item in the inventory until the user choice is the same as the inventory item
            foreach (var ItemValueChange in PlayerChange) {

                if (TradeUserChoice == ItemValueChange.Item_Name) {

                    ItemValueChange.Item_Amount += ChangeAmount;

                }

            }

            foreach (var StoreValueChange in StoreChange) {

                if (TradeUserChoice == StoreValueChange.Item_Name) {

                    StoreValueChange.Item_Amount -= ChangeAmount;

                }
            }
        }
    }
}