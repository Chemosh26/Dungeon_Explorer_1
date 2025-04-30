namespace DungeonExplorer
{
    // The Player class inherits from Creature and represents the user-controlled character.
    public class Player : Creature
    {
        private Inventory inventory; // Player's inventory to store items

        // Constructor to initialize player with a name and default health of 100
        public Player(string name) : base(name, 100)
        {
            inventory = new Inventory();
        }

        // Method to pick up an item and add it to the inventory
        public string PickUpItem(Item item)
        {
            if (item != null)
            {
                inventory.AddItem(item);
                return $"{Name} picked up {item.Name}.";
            }
            return "No item to pick up!";
        }

        // Method to drop an item from the inventory by its name
        public string DropItem(string itemName)
        {
            var item = inventory.GetItems().FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                inventory.RemoveItem(item);
                return $"Dropped {item.Name}.";
            }
            return "Item not found in inventory.";
        }

        // Method to use an item by its name
        public void UseItem(string itemName)
        {
            var item = inventory.GetItems().FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                item.Use(this); // Apply item effect to the player
                inventory.RemoveItem(item); // Assume item is consumed after use
            }
            else
            {
                Console.WriteLine("No such item in inventory.");
            }
        }

        // Override to return the player's current status including health and inventory
        public override string GetStatus()
        {
            return $"Player: {Name} | Health: {Health}\n{inventory.GetInventoryList()}";
        }

        // Heals the player by a given amount, capped at 100
        public void Heal(int amount)
        {
            Health += amount;
            if (Health > 100) Health = 100;
        }

        // Placeholder method to increase player's attack damage (can be expanded)
        public void IncreaseDamage(int amount)
        {
            Console.WriteLine($"{Name}'s damage potential increased by {amount} (not implemented yet).");
        }

        // Player attacks a monster using a weapon if available, or basic attack
        public void Attack(Monster monster)
        {
            // Use the first weapon found in inventory if any
            if (inventory.GetItems().Any(item => item is Weapon weapon))
            {
                Weapon weapon = inventory.GetItems().OfType<Weapon>().First();
                Console.WriteLine($"{Name} attacks with {weapon.Name}, dealing {weapon.Damage} damage.");
                monster.TakeDamage(weapon.Damage);
            }
            else
            {
                // If no weapon, use a default punch attack
                Console.WriteLine($"{Name} attacks with a basic punch, dealing 5 damage.");
                monster.TakeDamage(5);
            }
        }
    }
}
