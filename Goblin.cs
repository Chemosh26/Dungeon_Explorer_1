using System;

namespace DungeonExplorer
{
    // Represents a specific type of Monster: Goblin
    // The Goblin class inherits from the Monster class and overrides its attack behavior
    public class Goblin : Monster
    {
        // Constructor for the Goblin, setting its name, health, and damage
        public Goblin() : base("Goblin", 30, 10) { }

        // Override the Attack method for Goblin-specific attack behavior
        public override void Attack(Player player)
        {
            // Goblin's specific attack message with a dagger
            Console.WriteLine($"The Goblin lunges at {player.Name} with its dagger, dealing {Damage} damage.");
            // Call the base class's Attack method to apply the damage to the player
            base.Attack(player);
        }
    }
}
