using System;
using System.Collections.Generic;

namespace Store_RPG_Assignment {

    /// <summary>
    /// Functions to accsess the user/player inventory
    /// </summary>
    class Player_Inventory_List : Base_Inventory {

        /// <summary>
        /// List of "Inventory" objects
        /// </summary>
        public List<Inventory_Item> Inventory = new List<Inventory_Item>() {

        //Art Book
        new Inventory_Item{ Item_Name = "art book", Item_Amount = 0, Item_Cost = 1, Item_Pages = "50" },

        //Programming Book
        new Inventory_Item{ Item_Name = "c# book", Item_Amount = 0, Item_Cost = 20, Item_Pages = "150" },

        //Medic Book
        new Inventory_Item{ Item_Name = "medic book", Item_Amount = 0, Item_Cost = 15, Item_Pages = "200"},

        //Note Book
        new Inventory_Item{ Item_Name = "note book", Item_Amount = 0, Item_Cost = 5, Item_Pages = "50"}
        };
    }
}