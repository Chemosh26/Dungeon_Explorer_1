using System;
namespace DungeonExplorer
{
    // Represents a specific type of Monster: Vulture
    // The Vulture class inherits from the Monster class and overrides its attack behavior
    public class Vulture : Monster
    {
        // Constructor to initialize the Vulture with specific values for name, health, and damage
        public Vulture() : base("Vulture", 50, 5) { }

        // Override the Attack method to customize the Vulture's attack
        public override void Attack(Player player)
        {
            // Print a message describing the attack
            Console.WriteLine($"The Vulture pecks with its huge beak and damages {player.Name} by {Damage}.");
            // Call the base class Attack method to apply the damage
            base.Attack(player);
        }
    }
}