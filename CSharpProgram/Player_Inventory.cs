using System.Collections.Generic;

namespace Store_RPG_Assignment {
    /// <summary>
    /// The player inventory with functions inherited from the base inventory functions
    /// </summary>
    class Player_Inventory_List : Base_Inventory {

        /// <summary>
        /// List of "Inventory" objects
        /// </summary>
        public List<Inventory_Item> Inventory = new List<Inventory_Item>();

        ////Art Book
        //new Inventory_Item("art book", 0, 10, 50),

        //Programming Book
        //new Inventory_Item("c# book", 0, 20, 150),

        //Medic Book
        //new Inventory_Item("medic book", 0, 15, 200),

        //Note Book
        //new Inventory_Item("note book", 0, 5, 50)
        //};

    }
}