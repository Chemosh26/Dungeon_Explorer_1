using System;

namespace DungeonExplorer
{
    // Represents a specific type of Monster: Troll
    // The Troll class inherits from the Monster class and overrides its attack behavior
    public class Troll : Monster
    {
        // Constructor for the Troll, setting its name, health, and damage
        public Troll() : base("Troll", 40, 15) { }

        // Override the Attack method for Troll-specific attack behavior
        public override void Attack(Player player)
        {
            // Troll's specific attack message with a club swing
            Console.WriteLine($"The Troll swings down with a club at {player.Name}, causing {Damage} damage.");
            // Call the base class's Attack method to apply the damage to the player
            base.Attack(player);
        }
    }
}
