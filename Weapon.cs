using System;

namespace DungeonExplorer
{
    // The Weapon class inherits from Item and represents an item that deals damage
    public class Weapon : Item
    {
        // Damage value this weapon can deal
        public int Damage { get; set; }

        // Constructor to initialize name and damage of the weapon
        public Weapon(string name, int damage) : base(name, "Weapon")
        {
            Damage = damage;
        }

        // Returns a custom description of the weapon
        public override string GetDescription()
        {
            return $"{Name} [Weapon] - damages {Damage} HP";
        }

        // Defines how the weapon is used (e.g., during combat)
        public override void Use(Player player)
        {
            Console.WriteLine($"{player.Name} swings {Name}, causing {Damage} damage!");
        }

        // Returns the weapon's status info (description + attack power)
        public string GetStatus()
        {
            return $"{GetDescription()}, Attack Power: {Damage}";
        }
    }
}
