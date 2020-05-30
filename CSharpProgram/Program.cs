namespace Store_RPG_Assignment {

    /// <summary>
    /// Base Program
    /// </summary>
    class Program {
        static void Main()
        {
            //Initialize Game Manager
            Game_Manager PlayGame = new Game_Manager();

            //Bool to control the game loop
            bool RunGame = true;

            //Run the loop until the player wants to exit
            while (RunGame!=false) {
                switch (PlayGame.CurrentState) {
                    //Get the players name
                    case Game_Manager.GameState.GetPlayerName:
                        PlayGame.RunPlayerName();
                        break;
                    //Show the main menu
                    case Game_Manager.GameState.Menu:
                        PlayGame.RunMenu();
                        break;
                    //Show the trade menu
                    case Game_Manager.GameState.Trade:
                        PlayGame.RunTradeMenu();
                        break;
                    //Show the players inventory
                    case Game_Manager.GameState.PlayerInventoryMenu:
                        PlayGame.RunPlayerInventory();
                        break;
                    //Show the stores inventory
                    case Game_Manager.GameState.StoreInventoryMenu:
                        PlayGame.RunStoreInventory();
                        break;
                    //Exit the game
                    case Game_Manager.GameState.Exit:
                        PlayGame.RunExitGame();
                        RunGame=false;
                        break;
                    //Accsess the super user
                    case Game_Manager.GameState.SuperUser:
                        PlayGame.RunSuperUser();
                        break;
                }
            }
        }
    }
}