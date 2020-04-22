using System;
using System.Collections.Generic;
using System.Text;

namespace Store_RPG_Assignment {

    class Program {
        static void Main() {
            //Initialize Game Manager
            Game_Manager PlayGame = new Game_Manager();

            while (PlayGame.CurrentState != Game_Manager.GameState.Exit) {

                switch (PlayGame.CurrentState) {

                    case Game_Manager.GameState.GetPlayerName:
                        PlayGame.RunPlayerName();
                        break;

                    case Game_Manager.GameState.Menu:
                        PlayGame.RunMenu();
                        break;

                    case Game_Manager.GameState.Trade:
                        PlayGame.RunTradeMenu();
                        break;

                    case Game_Manager.GameState.PlayerInventoryMenu:
                        PlayGame.RunPlayerInventory(); 
                        break;

                    case Game_Manager.GameState.StoreInventoryMenu:
                        PlayGame.RunStoreInventory();
                        break;

                    case Game_Manager.GameState.Exit:
                        PlayGame.RunExitGame();
                        break;
                
                }
            }
        }
    }
}