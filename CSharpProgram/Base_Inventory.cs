using System;
using System.Collections.Generic;

namespace Store_RPG_Assignment {

    /// <summary>
    /// Base class for making an item
    /// </summary>
    public class Inventory_Item {

        //Constructor for making an inventory item, must provide all fields to make an item
        public Inventory_Item(string name, int amount, float cost, int pages) {

            Item_Name = name;
            Item_Amount = amount;
            Item_Cost = cost;
            Item_Pages = pages;
        }

        //Variables for an item
        //String for Item Name
        public string Item_Name;
        //Amount of items in the inventory
        public int Item_Amount;
        //Cost of the Item
        public float Item_Cost;
        //Pages in the book
        public int Item_Pages;

        /// <summary>
        /// Returns the name of the object as a string
        /// </summary>
        public string ReturnNameAsString {
            get { return Item_Name.ToString(); }
        }

        /// <summary>
        /// Returns the amount owned as a string
        /// </summary>
        public string ReturnAmountAsString {
            get { return Item_Amount.ToString(); }
        }

        /// <summary>
        /// Returns the cost of the item as a string
        /// </summary>
        public string ReturnCostAsString {
            get { return Item_Cost.ToString(); }
        }

        /// <summary>
        /// Return the pages of the item as a string
        /// </summary>
        public string ReturnPagesAsString {
            get { return Item_Pages.ToString(); }
        }
    }

    /// <summary>
    /// Holds the main functions to controlling the player and store inventory
    /// </summary>
    public class Base_Inventory {

        /// <summary>
        /// String to hold the user choice on what to sort the list by
        /// </summary>
        string SortChoice = "";

        //Currency of the player which changes depending on trades
        public float Currency = 35.0f;
        
        /// <summary>
        /// Virtual function that can be changed. Prints all the objects currently in the inventory
        /// </summary>
        /// <param name="Player_inventor"></param>
        public virtual void PrintInventory(List<Inventory_Item> Print_Inventory) {
            //Prints out each of the objects in the inventory
            foreach (var Item in Print_Inventory) {
                Console.WriteLine(
                    "Name: " + Item.Item_Name + " | " +
                    "Amount: " + Item.Item_Amount + " | " +
                    "Cost: " + Item.Item_Cost + " | " +
                    "Pages: " + Item.Item_Pages
                );
            }

            Console.WriteLine($"Current Money: ${Currency}");
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