using System;

namespace Store_RPG_Assignment {
    /// <summary>
    /// Functions and variables for the main menu
    /// </summary>
    class Menu {
        
        /// <summary>
        /// String for the user choice
        /// </summary>
        string MenuUserChoice = "";

        /// <summary>
        /// String for the player name
        /// </summary>
        string PlayerName = "";

        /// <summary>
        /// Ask for the users name
        /// </summary>
        public void GetName() {
            
            Console.WriteLine("Greetings, what is your name? ");
            PlayerName = Console.ReadLine();

            //while the user enters an empty name ask them for one
            while (PlayerName == "") {
                Console.Clear();
                Console.WriteLine("Please enter a name:");
                PlayerName = Console.ReadLine();
            }
        }

        /// <summary>
        /// Returns the Player name
        /// </summary>
        /// <returns></returns>
        public string ReturnName() {

            return PlayerName;

        }

        /// <summary>
        /// Returns the user choice for the main menu
        /// </summary>
        /// <returns></returns>
        public string ReturnMenuUserChoice() {

            return MenuUserChoice;

        }

        /// <summary>
        /// Print out the main menu and get the user input
        /// </summary>
        public void ShowMainMenu() {
            Console.WriteLine($"Welcome to the trading game, {PlayerName}!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("- Trade with the shop (trade)");
            Console.WriteLine("- View your Inventory (inventory)");
            Console.WriteLine("- View store Inventory (store)");
            Console.WriteLine("- Save Progress (save)");
            Console.WriteLine("- Quit the game (exit)");

            //Get user input
            MenuUserChoice = Console.ReadLine().ToLower();
        }
    }
}