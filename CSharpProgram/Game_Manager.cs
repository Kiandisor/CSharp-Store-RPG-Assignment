using System;

namespace Store_RPG_Assignment {
    class Game_Manager {

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
                switch (StartMenu.ReturnMenuUserChoice()) {
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

                TradeMenu.ShowTradeMenu();

                TradeMenu.ChangeInventory(ref UserInventory.Inventory, ref StoreInventory.Store_Stock_Inventory, TradeMenu.ReturnTradeUserChoice(), TradeMenu.ReturnItemAmount(), TradeMenu.ReturnTradeToChoice());

                

                //TradeMenu.ShowTradeMenu();

                ////Switch for the trade menu choice
                //switch (TradeMenu.ReturnTradeToChoice()) {

                //    case "to":
                //        TradeMenu.ChangeInventory(ref UserInventory.Inventory, ref StoreInventory.Store_Stock_Inventory, TradeMenu.GetItemChoice(), TradeMenu.TradeItemAmount(), TradeMenu.GetTo_Or_From());
                //        break;

                //    case "from":
                //        TradeMenu.ChangeInventory(ref UserInventory.Inventory, ref StoreInventory.Store_Stock_Inventory, TradeMenu.ReturnTradeUserChoice(), TradeMenu.TradeItemAmount(), true);
                //        break;

                //    case "menu":
                //        CurrentState = GameState.Menu;
                //        Console.Clear();
                //        break;
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

        ///// <summary>
        ///// Manages the Store Inventory Menu
        ///// </summary>
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
        
        ///// <summary>
        ///// Manages how to exit the game
        ///// </summary>
        public void RunExitGame() {

            Environment.Exit(0);
        }
    }
}
