using System;
using System.Collections.Generic;
using System.Text;

namespace Store_RPG_Assignment {
    class Super_User {
        public void AddItem(ref List<Inventory_Item> PlayerInventor) {        
            PlayerInventor.Add(new Inventory_Item() {
            Item_Name = Console.ReadLine(),
            Item_Amount = ,
            Item_Cost = ,
            Item_Pages = 
            });
        }
    }
}