using System;
using System.Collections.Generic;

namespace Store_RPG_Assignment {

    /// <summary>
    /// Functions and variables for the super user
    /// </summary>
    class Super_User {

        //Constructor of the super_user to create a new item for both inventories
        public Super_User() {

            CustomName = SetName();
            CustomAmount = SetAmount();
            CustomCost = SetCost();
            CustomPages = SetPages();;
        }

        string CustomName = "";
        int CustomAmount = 0;
        float CustomCost = 0f;
        int CustomPages = 0;

        /// <summary>
        /// Adds the new item creaded to both inventories
        /// </summary>
        /// <param name="PlayerInventor"></param>
        /// <param name="StoreInventor"></param>
        public void AddItemToInventories(ref List<Inventory_Item> PlayerInventor, ref List<Inventory_Item> StoreInventor) {
            PlayerInventor.Add(new Inventory_Item(CustomName, CustomAmount, CustomCost, CustomPages));

            StoreInventor.Add(new Inventory_Item(CustomName, CustomAmount, CustomCost, CustomPages));
        }

        /// <summary>
        /// Sets the name of the new item
        /// </summary>
        /// <returns></returns>
        public string SetName() {

            Console.WriteLine("Enter the name for the new book: ");

            string Name = Console.ReadLine();

            return Name;
        }

        /// <summary>
        /// Sets the amount of the item the store/player will start with
        /// </summary>
        /// <returns></returns>
        public int SetAmount() {

            Console.WriteLine($"How many {CustomName}(s) should the store and player start with?");

            //Gets the users amount
            string sChangeAmount = Console.ReadLine();

            //Bool to check if the users input can be parsed to a int
            bool CheckParse = int.TryParse(sChangeAmount, out CustomAmount);
            //If it can be parsed, set the ChangeAmount to the value of the string
            if (CheckParse == true) {

                CustomAmount = int.Parse(sChangeAmount);
                return CustomAmount;
            }

            //If not keep running the function until the user enters a valid input
            else {

                Console.WriteLine("That was not a valid input. Please enter a number.");
                return SetAmount();
            }
        }

        /// <summary>
        /// Sets the cost of the item
        /// </summary>
        /// <returns></returns>
        public float SetCost() {

            Console.WriteLine($"What will the cost of {CustomName} be?");

            //Gets the users amount
            string sChangeAmount = Console.ReadLine();

            //Bool to check if the users input can be parsed to a float
            bool CheckParse = float.TryParse(sChangeAmount, out CustomCost);
            //If it can be parsed, set the ChangeAmount to the value of the string
            if (CheckParse == true) {

                CustomCost = float.Parse(sChangeAmount);
                return CustomCost;
            }

            //If not keep running the function until the user enters a valid input
            else {

                Console.WriteLine("That was not a valid input. Please enter a number.");
                return SetAmount();
            }
        }

        /// <summary>
        /// Sets the amount of pages the item has
        /// </summary>
        /// <returns></returns>
        public int SetPages() {

            Console.WriteLine($"How many pages will {CustomName} have?");

            //Gets the users amount
            string sChangeAmount = Console.ReadLine();

            //Bool to check if the users input can be parsed to a int
            bool CheckParse = int.TryParse(sChangeAmount, out CustomPages);
            //If it can be parsed, set the ChangeAmount to the value of the string
            if (CheckParse == true) {

                CustomPages = int.Parse(sChangeAmount);
                return CustomPages;
            }

            //If not keep running the function until the user enters a valid input
            else {

                Console.WriteLine("That was not a valid input. Please enter a number.");
                return SetAmount();
            }
        }
    }
}