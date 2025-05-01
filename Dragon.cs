using System;

namespace DungeonExplorer
{
    // Represents a specific type of Monster: Dragon
    // The Dragon class inherits from the Monster class and overrides its attack behavior
    public class Dragon : Monster
    {
        // Constructor for the Dragon, setting its name, health, and damage
        public Dragon() : base("Dragon", 100, 25) { }

        // Override the Attack method for Dragon-specific attack behavior
        public override void Attack(Player player)
        {
            // Dragon's specific attack message with a fire breath
            Console.WriteLine($"The Dragon breathes a scolding cloud of fire at {player.Name}, causing {Damage} damage.");
            // Call the base class's Attack method to apply the damage to the player
            base.Attack(player);
        }
    }
}
