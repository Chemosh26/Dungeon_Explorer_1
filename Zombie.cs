using System;

namespace DungeonExplorer
{
    // Represents a specific type of Monster: Zombie
    // The Zombie class inherits from the Monster class and overrides its attack behavior
    public class Zombie : Monster
    {
        // Constructor for the Zombie, setting its name, health, and damage
        public Zombie() : base("Zombie", 80, 15) { }

        // Override the Attack method for Zombie-specific attack behavior
        public override void Attack(Player player)
        {
            // Zombie's specific attack message with a bite
            Console.WriteLine($"The Zombie lunges and bites at {player.Name}, causing {Damage} damage.");
            // Call the base class's Attack method to apply the damage to the player
            base.Attack(player);
        }
    }
}