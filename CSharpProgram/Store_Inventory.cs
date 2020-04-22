using System;
using System.Collections.Generic;

namespace CSharpProgram {
    /// <summary>
    /// Variables to make a store object
    /// </summary>
    class Store_Inventory {

        //Variables for an item/object:
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
    /// Functions to accsess the store inventory
    /// </summary>
    class Store_Inventory_List {

        /// <summary>
        /// List of "Inventory" objects
        /// </summary>
        public List<Store_Inventory> Store_Stock_Inventory = new List<Store_Inventory>() {

        //Art Book
        new Store_Inventory{ Item_Name = "art book", Item_Amount = 15, Item_Cost = 15, Item_Pages = "50" },

        //Programming Book
        new Store_Inventory{ Item_Name = "c# book", Item_Amount = 15, Item_Cost = 20, Item_Pages = "150" },

        //Medic Book
        new Store_Inventory{ Item_Name = "medic book", Item_Amount = 15, Item_Cost = 15, Item_Pages = "200"},

        //Note Book
        new Store_Inventory{ Item_Name = "note book", Item_Amount = 15, Item_Cost = 5, Item_Pages = "50"}
        };

        /// <summary>
        /// String to hold the user choice on what to sort the store list by
        /// </summary>
        string StoreSortChoice = "";

        /// <summary>
        /// Prints all the objects currently in the stores inventory
        /// </summary>
        /// <param name="Store_inventor"></param>
        public void PrintStoreInventory(List<Store_Inventory> Store_inventor) {
            //Print out each of the objects in the list being passed through
            foreach (var StoreItem in Store_inventor) {
                Console.WriteLine("Name: " + StoreItem.Item_Name + " | " +
                                  "Amount: " + StoreItem.Item_Amount + " | " +
                                  "Cost: " + StoreItem.Item_Cost + " | " +
                                  "Pages: " + StoreItem.Item_Pages);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Menu for getting the input to sort the store inventory
        /// </summary>
        public void SortStoreListMenu() {
            Console.WriteLine("Sort the list by: ");
            Console.WriteLine("- Amount owned (amount)");
            Console.WriteLine("- Item Name (name)");
            Console.WriteLine("- Item Pages (pages)");
            Console.WriteLine("- Return to menu (menu)");

            //Gets the user input and makes it lower case
            StoreSortChoice = Console.ReadLine().ToLower();
        }

        /// <summary>
        /// Returns the user sort choice
        /// </summary>
        public string ReturnStoreSortInventory() {

            return StoreSortChoice;
        
        }

        /// <summary>
        /// Sort List by amount owned
        /// </summary>
        /// <param name="ListToSort"></param>
        public void SortByAmountOwned(ref List<Store_Inventory> ListToSort) {

            ListToSort.Sort((x, y) => x.Item_Amount.CompareTo(y.Item_Amount));
        }

        /// <summary>
        /// Sort List by item name
        /// </summary>
        /// <param name="ListToSort"></param>
        public void SortByItemName(ref List<Store_Inventory> ListToSort) {

            ListToSort.Sort((x, y) => x.Item_Name.CompareTo(y.Item_Name));
        }

        /// <summary>
        /// Sort List by item pages
        /// </summary>
        /// <param name="ListToSort"></param>
        public void SortByItemPages(ref List<Store_Inventory> ListToSort) {

            ListToSort.Sort((x, y) => x.Item_Pages.CompareTo(y.Item_Pages));
        }
    }
}
