namespace DungeonExplorer
{
    // Represents a Monster, inheriting from Creature and implementing behavior for combat
    public class Monster : Creature
    {
        // The damage the monster deals when it attacks
        public int Damage { get; }

        // Constructor to initialize the Monster's name, health, and damage
        public Monster(string name, int health, int damage) : base(name, health)
        {
            Damage = damage;
        }

        // Polymorphic method for the Monster to attack a Player
        public virtual void Attack(Player player)
        {
            // Display attack information
            Console.WriteLine($"{Name} attacks {player.Name} for {Damage} damage.");
            // Player takes damage from the attack
            player.TakeDamage(Damage);
        }

        // Overrides the TakeDamage method to apply damage to the Monster's health
        public void TakeDamage(int damage)
        {
            Health -= damage;
            // Ensures health doesn't go below 0
            if (Health < 0)
                Health = 0;
        }

        // Override of the GetStatus method to include the Monster's health and damage
        public override string GetStatus()
        {
            return $"{Name} | Health: {Health} | Damage: {Damage}";
        }
    }
}
