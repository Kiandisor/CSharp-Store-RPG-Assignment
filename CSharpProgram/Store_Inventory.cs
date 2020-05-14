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
        
        //Default books:
        //Art Book
        //Programming Book
        //Medic Book
        //Note Book
    }
}