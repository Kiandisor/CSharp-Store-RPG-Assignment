using System;
using System.Collections.Generic;
using System.Text;

namespace Store_RPG_Assignment {
    /// <summary>
    /// Base class for making an item
    /// </summary>
    class Inventory_Item {

        //Variables for an item
        //String for Item Name
        public string Item_Name;
        //Amount of items in the inventory
        public int Item_Amount;
        //Cost of the Item
        public float Item_Cost;
        //Pages in the book
        public string Item_Pages;

    }

    /// <summary>
    /// Holds the main functions to controlling the player and store inventory
    /// </summary>
    class Base_Inventory {

        /// <summary>
        /// String to hold the user choice on what to sort the list by
        /// </summary>
        string SortChoice = "";

        /// <summary>
        /// Prints all the objects currently in the inventory
        /// </summary>
        /// <param name="Player_inventor"></param>
        public void PrintInventory(List<Inventory_Item> Print_Inventory) {
            //Prints out each of the objects in the player inventory
            foreach (var Item in Print_Inventory) {
                Console.WriteLine("Name: " + Item.Item_Name + " | " +
                                  "Amount: " + Item.Item_Amount + " | " +
                                  "Cost: " + Item.Item_Cost + " | " +
                                  "Pages: " + Item.Item_Pages);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Menu for getting the input to sort the player inventory
        /// </summary>
        public void SortListMenu() {
            Console.WriteLine("Sort the list by: ");
            Console.WriteLine("- Amount owned (amount)");
            Console.WriteLine("- Item Name (name)");
            Console.WriteLine("- Item Pages (pages)");
            Console.WriteLine("- Return to menu (menu)");

            //Gets the user input and makes it lower case
            SortChoice = Console.ReadLine().ToLower();
        }

        /// <summary>
        /// Returns the user sort choice
        /// </summary>
        public string ReturnSortInventory() {

            return SortChoice;
        }

        /// <summary>
        /// Sort List by amount owned
        /// </summary>
        /// <param name="ListToSort"></param>
        public void SortByAmountOwned(ref List<Inventory_Item> ListToSort) {

            ListToSort.Sort((x, y) => x.Item_Amount.CompareTo(y.Item_Amount));
        }

        /// <summary>
        /// Sort List by item name
        /// </summary>
        /// <param name="ListToSort"></param>
        public void SortByItemName(ref List<Inventory_Item> ListToSort) {

            ListToSort.Sort((x, y) => x.Item_Name.CompareTo(y.Item_Name));
        }

        /// <summary>
        /// Sort List by item pages
        /// </summary>
        /// <param name="ListToSort"></param>
        public void SortByItemPages(ref List<Inventory_Item> ListToSort) {

            ListToSort.Sort((x, y) => x.Item_Pages.CompareTo(y.Item_Pages));
        }
    }
}