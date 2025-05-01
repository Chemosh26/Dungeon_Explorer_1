using System;
namespace DungeonExplorer
{
    // Represents a specific type of Monster: DarkKnight
    // The DarkKnight class inherits from the Monster class and overrides its attack behavior
    public class DarkKnight : Monster
    {
        // Constructor to initialize the DarkKnight with specific values for name, health, and damage
        public DarkKnight() : base("DarkKnight", 50, 5) { }

        // Override the Attack method to customize the DarkKnight's attack
        public override void Attack(Player player)
        {
            // Print a message describing the attack
            Console.WriteLine($"The DarkKnight cleavers at {player.Name}, causing {Damage} damage.");
            // Call the base class Attack method to apply the damage
            base.Attack(player);
        }
    }
}
