using System;

namespace Store_RPG_Assignment {
    /// <summary>
    /// Functions and variables for the main menu
    /// </summary>
    class Menu {

        /// <summary>
        /// Returns the Player name
        /// </summary>
        /// <returns></returns>
        public string ReturnName { get; private set; } = "";

        /// <summary>
        /// Returns the user choice for the main menu
        /// </summary>
        /// <returns></returns>
        public string ReturnMenuUserChoice { get; private set; } = "";

        /// <summary>
        /// Ask for the users name
        /// </summary>
        public void GetName() {
            
            Console.WriteLine("Greetings, what is your name? ");
            ReturnName = Console.ReadLine();

            //while the user enters an empty name ask them for one
            while (ReturnName == "") {
                Console.Clear();
                Console.WriteLine("Please enter a name:");
                ReturnName = Console.ReadLine();
            }
        }

        /// <summary>
        /// Print out the main menu and get the user input
        /// </summary>
        public void ShowMainMenu() {
            Console.WriteLine($"Welcome to the trading game, {ReturnName}!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("- Trade with the shop (trade)");
            Console.WriteLine("- View your Inventory (inventory)");
            Console.WriteLine("- View store Inventory (store)");
            Console.WriteLine("- Quit the game (exit)");

            //Get user input
            ReturnMenuUserChoice = Console.ReadLine().ToLower();
        }
    }
}