using System.Collections.Generic;

namespace Store_RPG_Assignment {
    /// <summary>
    /// The store inventory with functions inherited from the base inventory functions
    /// </summary>
    class Store_Inventory_List : Base_Inventory {

        /// <summary>
        /// List of "Inventory" objects
        /// </summary>
        public List<Inventory_Item> Store_Stock_Inventory = new List<Inventory_Item>();

        //Art Book
        //new Inventory_Item("art book", 15, 15, 50 ),

        //Programming Book
        //new Inventory_Item("c# book", 15, 20, 150 ),

        //Medic Book
        //new Inventory_Item("medic book", 15, 15, 200),

        //Note Book
        //new Inventory_Item("note book", 15, 5, 50)
        //};
    }
}