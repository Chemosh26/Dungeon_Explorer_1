using DungeonExplorer;
using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Game
    {
        private Player? player; // The player object
        private GameMap gameMap; // The map of all rooms
        private Room? currentRoom; // The current room the player is in

        public Game()
        {
            // Create a new player
            player = new Player("Hero");

            // Create a new game map
            gameMap = new GameMap();

            // Create rooms with descriptions and items
            Room room1 = new Room("A dark and damp dungeon room...", new Weapon("Rusty Sword", 10));
            Room room2 = new Room("A brightly lit room with a huge chandelier...", new Potion("Healing Potion", 25));
            Room room3 = new Room("A mysterious cave with mist...", new Potion("Mega Health Potion", 50));
            Room room4 = new Room("A cold cavern with icy walls...", new Weapon("Axe", 30));
            Room room5 = new Room("A dimly lit corridor with runes...", new Weapon("Bow", 15));
            Room room6 = new Room("A flooded chamber with a troll...", new Weapon("Dagger", 20));
            Room room7 = new Room("A fiery throne room with a dark knight...", new Weapon("Hammer", 25));

            // Add rooms to the map
            gameMap.AddRoom("Room1", room1);
            gameMap.AddRoom("Room2", room2);
            gameMap.AddRoom("Room3", room3);
            gameMap.AddRoom("Room4", room4);
            gameMap.AddRoom("Room5", room5);
            gameMap.AddRoom("Room6", room6);
            gameMap.AddRoom("Room7", room7);

            // Add monsters to rooms
            room1.AddMonster(new Goblin());
            room2.AddMonster(new Vulture());
            room3.AddMonster(new Dragon());
            room4.AddMonster(new Zombie());
            room5.AddMonster(new Mummy());
            room6.AddMonster(new Troll());
            room7.AddMonster(new DarkKnight());

            // Start the player in room 1
            currentRoom = room1;
        }

        public void Start()
        {
            // Ask the player for their name
            Console.Write("Enter your name: ");
            string? playerName = Console.ReadLine();
            playerName ??= "Hero"; // Use "Hero" if no name is given

            // Create the player with the entered name
            player = new Player(playerName);

            // Welcome message and show the room
            Console.WriteLine($"Welcome, {playerName}! You find yourself in a room.");
            ShowRoom();
            Play(); // Start the main game loop
        }
         
        public void ShowRoom()
        {
            // Show the description of the current room
            if (currentRoom != null)
            {
                Console.WriteLine($"Room Description: {currentRoom.GetDescription()}");

                // Show item in the room, if any
                if (currentRoom.GetItem() != null)
                {
                    Console.WriteLine($"You see a {currentRoom.GetItem().GetDescription()} here.");
                }

                // Show any monsters in the room
                currentRoom.ShowMonsters();
            }
            else
            {
                Console.WriteLine("You are in an unknown room.");
            }
        }

        private void Play()
        {
            // Game loop
            while (true)
            {
                Console.Write("\nWhat do you want to do?\n>pick\n>drop\n>use\n>status\n>move\n>quit\n>fight\n> ");
                string? command = Console.ReadLine()?.ToLower();

                // Handle commands
                switch (command)
                {
                    case "pick":
                        PickUpItem();
                        break;

                    case "drop":
                        DropItem();
                        break;

                    case "status":
                        ShowPlayerStatus();
                        break;

                    case "move":
                        MoveRoom();
                        break;

                    case "quit":
                        Console.WriteLine("Thanks for playing!");
                        Console.ReadKey();
                        return;

                    case "use":
                        UseItem();
                        break;

                    case "fight":
                        FightMonster();
                        break;

                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }

        private void PickUpItem()
        {
            // Player picks up item in the room
            if (currentRoom != null)
            {
                Item? roomItem = currentRoom.GetItem();
                if (roomItem != null && player != null)
                {
                    string message = player.PickUpItem(roomItem);
                    Console.WriteLine(message);
                    currentRoom.RemoveItem(); // Remove the item from room after pickup
                }
                else
                {
                    Console.WriteLine("There is no item to pick up or player not found.");
                }
            }
            else
            {
                Console.WriteLine("You are in an unknown room.");
            }
        }

        private void DropItem()
        {
            // Player drops an item
            if (player == null)
                return;

            Console.WriteLine("Enter item name to drop:");
            string? itemName = Console.ReadLine();

            if (itemName != null)
            {
                player.DropItem(itemName);
            }
        }

        private void ShowPlayerStatus()
        {
            // Show player's current status
            if (player != null)
            {
                Console.WriteLine(player.GetStatus());
            }
        }

        private void MoveRoom()
        {
            // Let player choose and move to another room
            if (gameMap == null)
                return;

            Console.WriteLine("Choose a room to move to:");
            List<string> roomNames = gameMap.GetRoomNames();

            // Show available rooms
            for (int i = 0; i < roomNames.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {roomNames[i]}");
            }

            // Get player input and move
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int choice))
            {
                choice -= 1; // Adjust index

                if (choice >= 0 && choice < roomNames.Count)
                {
                    string chosenRoomName = roomNames[choice];
                    currentRoom = gameMap.GetRoom(chosenRoomName);
                    ShowRoom();
                }
                else
                {
                    Console.WriteLine("Invalid room choice.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }

        private void UseItem()
        {
            // Use an item from inventory
            if (player == null)
                return;

            Console.Write("Enter the name of the item you want to use: ");
            string? itemName = Console.ReadLine();
            if (itemName != null)
            {
                player.UseItem(itemName);
            }
        }

        private void FightMonster()
        {
            // Player fights a monster in the room
            if (currentRoom != null && currentRoom.Monsters.Count > 0)
            {
                Monster monster = currentRoom.Monsters[0]; // Fight the first monster
                Console.WriteLine($"You are fighting a {monster.Name}!");

                // Fight loop
                while (player.IsAlive() && monster.IsAlive())
                {
                    Console.WriteLine($"You have {player.Health} HP.");
                    Console.WriteLine("Choose an action: [Attack] [Use Item]");

                    string? action = Console.ReadLine()?.ToLower();

                    if (action == "attack")
                    {
                        player.Attack(monster); // Player attacks monster
                    }
                    else if (action == "use item")
                    {
                        UseItem(); // Player uses item
                    }

                    // Monster attacks back
                    if (monster.IsAlive())
                    {
                        monster.Attack(player);
                    }

                    // Check who won
                    if (!player.IsAlive())
                    {
                        Console.WriteLine($"You were defeated by {monster.Name}.");
                    }
                    else if (!monster.IsAlive())
                    {
                        Console.WriteLine($"You defeated the {monster.Name}!");
                        currentRoom.RemoveMonster(monster);
                    }
                }
            }
            else
            {
                Console.WriteLine("No monsters to fight in this room.");
            }
        }

        public void StartFight()
        {
            // An extra method to start a fight
            if (currentRoom.Monsters.Count == 0)
            {
                Console.WriteLine("There are no monsters to fight in this room.");
                return;
            }

            Monster monster = currentRoom.Monsters[0]; // Fight the first monster
            Console.WriteLine($"You are fighting {monster.Name}!");
            // Fight logic continues here (not implemented in this method)
        }
    }
}
