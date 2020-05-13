using System;
using System.Collections.Generic;
using System.Text;

namespace Store_RPG_Assignment {
    class Super_User {
        public string SetCustomName { get; private set; } = "";
        public int SetCustomAmount { get; private set; } = 0;
        public float SetCustomCost { get; private set; } = 0f;
        public string SetCustomPages { get; private set; } = "";

        public void AddItemToPlayer(ref List<Inventory_Item> PlayerInventor) {        
            PlayerInventor.Add(new Inventory_Item() {
            Item_Name = SetCustomName,
            Item_Amount = SetCustomAmount,
            Item_Cost = SetCustomCost,
            Item_Pages = SetCustomPages
            });
        }
    }
}