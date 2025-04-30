using System;
namespace DungeonExplorer
{
    // Represents a specific type of Monster: Mummy
    // The Mummy class inherits from the Monster class and overrides its attack behavior
    public class Mummy : Monster
    {
        // Constructor to initialize the Mummy with specific values for name, health, and damage
        public Mummy() : base("Mummy", 50, 5) { }

        // Override the Attack method to customize the Mummy's attack
        public override void Attack(Player player)
        {
            // Print a message describing the attack
            Console.WriteLine($"The Mummy strangles {player.Name} with its cloth causing {Damage} damage.");
            // Call the base class Attack method to apply the damage
            base.Attack(player);
        }
    }
}