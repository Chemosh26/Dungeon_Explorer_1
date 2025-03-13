using System;
using System.Media;
using System.Numerics;

namespace DungeonExplorer
{
    // The Game class manages the overall flow of the dungeon exploration game.
    internal class Game
    {
        // Private fields for the player and the room the player is in.
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player
            currentRoom = new Room("A dark and damp dungeon room.", "Rusty Sword");
        }

        // Starts the game by getting the player's name and displaying the initial room state.
        public void Start()
        {
            Console.Write("Enter your name: "); // Prompting the user for their name.
            string playerName = Console.ReadLine(); // Reading user input.
            player = new Player(playerName); // Creating a new Player object with the entered name.

            Console.WriteLine($"Welcome, {playerName}! You find yourself in a room.");
            ShowRoom(); // Displaying the room's details.
            Play(); // Initiating the game loop.
        }

        // Displays the room description and any available item.
        private void ShowRoom()
        {
            Console.WriteLine($"Room Description: {currentRoom.GetDescription()}");

            // Checking if there is an item in the room and displaying it.
            if (currentRoom.GetItem() != null)
            {
                Console.WriteLine($"You see a {currentRoom.GetItem()} here.");
            }
        }

        // Main game loop that proccesses user commands
        private void Play()
        {
            while (true) // Infinite loop to keep the game running until the user quits.
            {
                Console.Write("\nWhat do you want to do?\n>pick\n>drop\n>status\n>quit\n");
                string command = Console.ReadLine().ToLower(); // Convert input to lowercase for consistency.

                switch (command)
                {
                    case "pick": // Picking up an item from the room.
                        if (currentRoom.GetItem() != null)
                        {
                            Console.WriteLine(player.PickUpItem(currentRoom.RemoveItem())); // Player picks up the item.
                        }
                        else
                        {
                            Console.WriteLine("Inventory Full! Also there's nothing to pick up."); // No item available.
                        }
                        break;

                    case "drop": // Dropping the currently held item.
                        {
                            Console.WriteLine(player.DropItem());
                        }
                        break;

                    case "status": // Displaying the player's status, including inventory.
                        Console.WriteLine(player.GetStatus());
                        break;

                    case "quit": // Exiting the game.
                        Console.WriteLine("Thanks for playing!");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return; // Exits the loop and ends the game.

                    default: // Handling invalid commands.
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }
    }
}
