using System.Collections.Generic;

namespace DungeonExplorer
{
    // The Player class represents a character in the dungeon game.
    public class Player
    {
        // Private fields to store the player's name, health, and inventory.
        private string name;
        private int health;
        private string inventory;

        // Initializes a player with a given name, full health, and an empty inventory.
        public Player(string name)
        {
            this.name = name;
            this.health = 100; // Default health value.
            this.inventory = null; // The player starts without any items.
        }

        // Method to pick up an item and store it in the player's inventory.
        public string PickUpItem(string item)
        {
            if (inventory == null) // Check if the inventory is empty.
            {
                inventory = item; // Assign the item to inventory.
                return $"{name} picked up {item}.";
            }
            return "Inventory Full! Also there's nothing to pick up."; //Message when trying to pick up an full inventory
        }

        // Method to drop the currently held item.
        public string DropItem()
        {
            if (inventory != null) // Check if there's an item to drop.
            {
                string droppedItem = inventory;
                inventory = null; // Clear the inventory.
                return $"Dropped {droppedItem}.";
            }
            return "Inventory is empty no item to drop!"; // Message when trying to drop an empty inventory.
        }

        // Method to return the player's current status, including health and inventory details.
        public string GetStatus()
        {
            return $"Player: {name} | Health: {health} | Inventory: {(inventory ?? "Empty")}";
        }
    }
}
