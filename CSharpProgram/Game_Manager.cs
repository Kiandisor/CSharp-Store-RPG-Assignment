﻿using System;
using System.IO;

namespace Store_RPG_Assignment {
    class Game_Manager {

        //Default Constructor that sets up the inventories from the respective files
        public Game_Manager() {

            //Read in the text from the Player_Inventory file
            string[] PlayerItems = File.ReadAllLines("PlayerInventory.txt");

            for(int Count = 0; Count < PlayerItems.Length; Count++) {

                string[] ItemProperties = PlayerItems[Count].Split('-'); //Splits each line to the array

                string name = ItemProperties[0]; //Assigns the name to the first string in the array
                int amount = int.Parse(ItemProperties[1]); //Assigns the amount to the second string in the array
                float cost = float.Parse(ItemProperties[2]); //Assigns the cost to the third string in the array
                int pages = int.Parse(ItemProperties[3]); //Assigns the pages to the foourth string in the array

                UserInventory.Inventory.Add(new Inventory_Item(name, amount, cost, pages)); //Adds the item to the player inventory
            }

            //Read in the text from the Store_Inventory file
            string[] StoreItems = File.ReadAllLines("StoreInventory.txt");

            for (int Count = 0; Count < StoreItems.Length; Count++) {

                string[] ItemProperties = StoreItems[Count].Split('-'); //Splits each line to the array

                string name = ItemProperties[0]; //Assigns the name to the first string in the array
                int amount = int.Parse(ItemProperties[1]); //Assigns the amount to the second string in the array
                float cost = float.Parse(ItemProperties[2]); //Assigns the cost to the third string in the array
                int pages = int.Parse(ItemProperties[3]); //Assigns the pages to the fourth string in the array

                StoreInventory.Store_Stock_Inventory.Add(new Inventory_Item(name, amount, cost, pages)); //Adds the item to the store inventory
            }
        }

        //Initialise objects
        Menu StartMenu = new Menu(); //Main Menu Object
        Trading_Menu TradeMenu = new Trading_Menu(); //Trading Menu object
        Player_Inventory_List UserInventory = new Player_Inventory_List(); //Player Inventory
        Store_Inventory_List StoreInventory = new Store_Inventory_List(); //Store Inventory

        /// <summary>
        /// Enum for the state of the game
        /// </summary>
        public enum GameState {
            GetPlayerName, //0
            Menu, //1
            Trade, //2
            PlayerInventoryMenu, //3
            StoreInventoryMenu, //4
            Exit, //5
            SuperUser //6
        }

        /// <summary>
        /// GameState variable for switches, default is 0/GetPlayerName
        /// </summary>
        public GameState CurrentState = GameState.GetPlayerName;

        /// <summary>
        /// Manages getting the player name
        /// </summary>
        public void RunPlayerName() {

            //Get the player name if there isn't one and the current state is 0/GetPlayerName
            if (CurrentState == GameState.GetPlayerName) {

                StartMenu.GetName();

                CurrentState = GameState.Menu;

            }

            //If there is a name then go straight to the menu
            else {
                CurrentState = GameState.Menu;
            }
        }

        /// <summary>
        /// Manages the Menu
        /// </summary>
        public void RunMenu() {

            //Run the game while the current state is menu 
            while (CurrentState == GameState.Menu) {
                Console.Clear();
                StartMenu.ShowMainMenu();

                //Switch for the main menu choice
                switch (StartMenu.ReturnMenuUserChoice) {
                    case "trade":
                        //Open Trade Menu and clears the screen
                        Console.Clear();
                        CurrentState = GameState.Trade;
                        //TradeMenu.ShowTradeMenu();
                        break;

                    case "inventory":
                        //Open User Invertory
                        Console.Clear();
                        CurrentState = GameState.PlayerInventoryMenu;
                        break;

                    case "store":
                        //Open the store inventory
                        Console.Clear();
                        CurrentState = GameState.StoreInventoryMenu;
                        RunStoreInventory();
                        break;

                    case "save":
                        //Save the game to a text file
                        Console.WriteLine("You saved the game!");
                        break;

                    case "exit":
                        //Quit the game
                        CurrentState = GameState.Exit;
                        break;

                    case "super":
                        //Run the super user command
                        CurrentState = GameState.SuperUser;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a choice from above.");
                        break;
                }
            }
        }

        /// <summary>
        /// Manages the Trade Menu
        /// </summary>
        public void RunTradeMenu() {

            //Run the trade menu while the gamestate is trade
            while (CurrentState == GameState.Trade) {

                TradeMenu.ShowTradeMenu(StoreInventory.Store_Stock_Inventory);

                TradeMenu.ChangeInventory(ref UserInventory.Inventory, ref StoreInventory.Store_Stock_Inventory, 
                    TradeMenu.ReturnTradeUserChoice, TradeMenu.ReturnItemAmount, TradeMenu.ReturnTradeToChoice, UserInventory.Currency);


                CurrentState = GameState.Menu;
            }
        }

        ///// <summary>
        ///// Manages the Player Inventory Menu
        ///// </summary>
        public void RunPlayerInventory() {
            while (CurrentState == GameState.PlayerInventoryMenu) {

                UserInventory.SortListMenu();

                switch (UserInventory.ReturnSortInventory()) {

                    case "amount":
                        Console.Clear();
                        UserInventory.SortByAmountOwned(ref UserInventory.Inventory);
                        UserInventory.PrintInventory(UserInventory.Inventory);
                        break;

                    case "name":
                        Console.Clear();
                        UserInventory.SortByItemName(ref UserInventory.Inventory);
                        UserInventory.PrintInventory(UserInventory.Inventory);
                        break;

                    case "pages":
                        Console.Clear();
                        UserInventory.SortByItemPages(ref UserInventory.Inventory);
                        UserInventory.PrintInventory(UserInventory.Inventory);
                        break;

                    case "menu":
                        Console.Clear();
                        CurrentState = GameState.Menu;
                        break;
                }
            }
        }

        /// <summary>
        /// Manages the Store Inventory Menu
        /// </summary>
        public void RunStoreInventory() {
            while (CurrentState == GameState.StoreInventoryMenu) {

                StoreInventory.SortListMenu();

                switch (StoreInventory.ReturnSortInventory()) {

                    case "amount":
                        Console.Clear();
                        StoreInventory.SortByAmountOwned(ref StoreInventory.Store_Stock_Inventory);
                        StoreInventory.PrintInventory(StoreInventory.Store_Stock_Inventory);
                        break;

                    case "name":
                        Console.Clear();
                        StoreInventory.SortByItemName(ref StoreInventory.Store_Stock_Inventory);
                        StoreInventory.PrintInventory(StoreInventory.Store_Stock_Inventory);
                        break;

                    case "pages":
                        Console.Clear();
                        StoreInventory.SortByItemPages(ref StoreInventory.Store_Stock_Inventory);
                        StoreInventory.PrintInventory(StoreInventory.Store_Stock_Inventory);
                        break;

                    case "menu":
                        Console.Clear();
                        CurrentState = GameState.Menu;
                        break;
                }
            }
        }

        /// <summary>
        /// Manages the Super User Menu
        /// </summary>
        public void RunSuperUser() {
            while (CurrentState == GameState.SuperUser) {

                Super_User NewItem = new Super_User();

                NewItem.AddItemToInventories(ref UserInventory.Inventory, ref StoreInventory.Store_Stock_Inventory);

                CurrentState = GameState.Menu;
            }
        }
        
        /// <summary>
        /// Manages how to exit the game
        /// </summary>
        public void RunExitGame() {

            string[] PlayerItemOutput = new string[UserInventory.Inventory.Count];

            foreach (var Item in UserInventory.Inventory) {;

                int count = 0;

                string name = Item.ReturnNameAsString;
                string amount = Item.ReturnAmountAsString;
                string cost = Item.ReturnCostAsString;
                string pages = Item.ReturnPagesAsString;

                string text = name + "-" + amount + "-" + cost + "-" + pages;

                PlayerItemOutput[count] = text;
            }

            string[] StoreItemOutput = new string[StoreInventory.Store_Stock_Inventory.Count];

            foreach (var Item in StoreInventory.Store_Stock_Inventory) {

                int count = 0;

                string name = Item.Item_Name;
                string amount = Item.ReturnAmountAsString;
                string cost = Item.ReturnCostAsString;
                string pages = Item.ReturnPagesAsString;

                string text = name + "-" + amount + "-" + cost + "-" + pages;

                StoreItemOutput[count] = text;
            }

            File.WriteAllLines("C:/Users/User/Documents/GitHub/CSharp-Store-RPG-Assignment/CSharpProgram/Versions/Debug/netcoreapp3.1/PlayerInventoryOut.txt", PlayerItemOutput);

            File.WriteAllLines("C:/Users/User/Documents/GitHub/CSharp-Store-RPG-Assignment/CSharpProgram/Versions/Debug/netcoreapp3.1/StoreInventoryOut.txt", StoreItemOutput);

            Environment.Exit(0);
        }
    }
}
