using System;
using System.Collections.Generic;

namespace CSharpProgram {
    /// <summary>
    /// Variables to make a player inventory object
    /// </summary>
    class Player_Inventory {

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
    /// Functions to accsess the user/player inventory
    /// </summary>
    class Player_Inventory_List {

        /// <summary>
        /// List of "Inventory" objects
        /// </summary>
        public List<Player_Inventory> Inventory = new List<Player_Inventory>() {

        //Art Book
        new Player_Inventory{ Item_Name = "art book", Item_Amount = 0, Item_Cost = 1, Item_Pages = "50" },

        //Programming Book
        new Player_Inventory{ Item_Name = "c# book", Item_Amount = 0, Item_Cost = 20, Item_Pages = "150" },

        //Medic Book
        new Player_Inventory{ Item_Name = "medic book", Item_Amount = 0, Item_Cost = 15, Item_Pages = "200"},

        //Note Book
        new Player_Inventory{ Item_Name = "note book", Item_Amount = 0, Item_Cost = 5, Item_Pages = "50"}
        };

        /// <summary>
        /// String to hold the user choice on what to sort the list by
        /// </summary>
        string SortChoice = "";

        /// <summary>
        /// Prints all the objects currently in the players inventory
        /// </summary>
        /// <param name="Player_inventor"></param>
        public void PrintInventory(List<Player_Inventory> Player_inventor) {
            //Prints out each of the objects in the player inventory
            foreach (var Item in Player_inventor) {
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
        public void SortByAmountOwned(ref List<Player_Inventory> ListToSort) {

            ListToSort.Sort((x,y) => x.Item_Amount.CompareTo(y.Item_Amount));
        }

        /// <summary>
        /// Sort List by item name
        /// </summary>
        /// <param name="ListToSort"></param>
        public void SortByItemName(ref List<Player_Inventory> ListToSort) {

            ListToSort.Sort((x,y) => x.Item_Name.CompareTo(y.Item_Name));
        }

        /// <summary>
        /// Sort List by item pages
        /// </summary>
        /// <param name="ListToSort"></param>
        public void SortByItemPages(ref List<Player_Inventory> ListToSort) {

            ListToSort.Sort((x,y) => x.Item_Pages.CompareTo(y.Item_Pages));
        }
    }
}