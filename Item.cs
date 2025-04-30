namespace DungeonExplorer
{
    // Abstract base class for all collectible items (e.g., weapons, potions)
    public abstract class Item : ICollectible
    {
        // Name of the item (e.g., "Sword", "Health Potion")
        public string Name { get; }

        // Type of the item (e.g., "Weapon", "Potion")
        public string Type { get; }

        // Constructor to initialize name and type
        protected Item(string name, string type)
        {
            Name = name;
            Type = type;
        }

        // Abstract method to get a description of the item (must be overridden in subclasses)
        public abstract string GetDescription();

        // Abstract method to define how the item is used by a player
        public abstract void Use(Player player); // Returns nothing (void)
    }
}