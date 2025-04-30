namespace DungeonExplorer
{
    // Abstract base class for all creatures (e.g., Player, Monster)
    public abstract class Creature : IDamageable
    {
        // Creature's name
        public string Name { get; protected set; }

        // Creature's current health
        public int Health { get; protected set; }

        // Constructor to initialize name and health
        protected Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }

        // Method to apply damage to the creature
        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0; // Ensure health doesn't go below 0
        }

        // Check if the creature is still alive
        public bool IsAlive()
        {
            return Health > 0;
        }

        // Get current status as a string
        public virtual string GetStatus()
        {
            return $"{Name} | Health: {Health}";
        }
    }
}