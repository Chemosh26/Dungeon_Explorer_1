namespace DungeonExplorer
{
    // Potion is a type of Item that restores the player's health
    public class Potion : Item
    {
        // Amount of health the potion restores
        public int HealAmount { get; }

        // Constructor to initialize the potion's name and healing amount
        public Potion(string name, int healAmount) : base(name, "Potion")
        {
            HealAmount = healAmount;
        }

        // Provides a description of the potion
        public override string GetDescription()
        {
            return $"{Name} [Potion] - Heals {HealAmount} HP";
        }

        // Applies the potion effect to the player (restores health)
        public override void Use(Player player)
        {
            player.Heal(HealAmount); // Increase player's health
            Console.WriteLine($"{player.Name} drinks {Name} and restores {HealAmount} health.");
        }
    }
}