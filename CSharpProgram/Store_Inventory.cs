using System;
using System.Collections.Generic;

namespace Store_RPG_Assignment {

    /// <summary>
    /// The store inventory with functions inherited from the base inventory functions
    /// </summary>
    public class Store_Inventory_List:Base_Inventory {

        /// <summary>
        /// List of "Inventory" objects
        /// </summary>
        public List<Inventory_Item> Store_Stock_Inventory = new List<Inventory_Item>();

        /// <summary>
        /// Overides the PrintInventory function in Base_Inventory to not show the currency the store has
        /// </summary>
        /// <param name="Print_Inventory"></param>
        public override void PrintInventory(List<Inventory_Item> Print_Inventory)
        {
            //Prints out each of the objects in the store inventory
            foreach (var Item in Print_Inventory) {
                Console.WriteLine("Name: "+Item.Item_Name+" | "+
                                  "Amount: "+Item.Item_Amount+" | "+
                                  "Cost: "+Item.Item_Cost+" | "+
                                  "Pages: "+Item.Item_Pages);
            }

            Console.WriteLine();
        }

        //Default books:
        //Art Book
        //Programming Book
        //Medic Book
        //Note Book
    }
}