using DungeonExplorer;

public class Room
{
    private string description;     // Description of the room
    private Item? item;             // Optional single item in the room
    private List<Monster> monsters = new List<Monster>(); // Unused private list (see note below)

    public string Name { get; }     // Name of the room (read-only)
    public List<Item> Items { get; } // List of items in the room
    public List<Monster> Monsters { get; } // List of monsters in the room

    // Constructor for a room with a description and a single optional item
    public Room(string description, Item? item)
    {
        this.description = description ?? throw new ArgumentNullException(nameof(description)); // Prevent null descriptions
        this.item = item;
        Items = new List<Item>();     // Initialize item list
        Monsters = new List<Monster>(); // Initialize monster list
        Name = "Unnamed Room";        // Default name

        if (item != null)
        {
            Items.Add(item); // Add to Items list too
        }
    }

    // Constructor for a room with a name only (no item, default description)
    public Room(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name)); // Prevent null names
        Items = new List<Item>();     // Initialize item list
        Monsters = new List<Monster>(); // Initialize monster list
        description = "No description provided"; // Default description
    }

    // Get the room's description
    public string GetDescription() => description;

    // Get the optional item (if any) in the room
    public Item? GetItem() => item;

    // Remove the item from the room and return it
    public Item? RemoveItem()
    {
        Item? removedItem = item;
        item = null; // Set item to null after removing
        return removedItem;
    }

    // Add a monster to the room's monster list
    public void AddMonster(Monster monster)
    {
        Monsters.Add(monster);
    }

    // Display all monsters currently in the room
    public void ShowMonsters()
    {
        if (Monsters.Count == 0)
        {
            Console.WriteLine("There are no monsters to fight in this room.");
        }
        else
        {
            foreach (var monster in Monsters)
            {
                Console.WriteLine($"Monster: {monster.Name}, Health: {monster.Health}");
            }
        }
    }

    // Remove a specific monster from the room
    public void RemoveMonster(Monster monster)
    {
        Monsters.Remove(monster);
    }

    // Start a fight with the first monster in the room (placeholder for battle logic)
    public void StartFight()
    {
        if (Monsters.Count == 0)
        {
            Console.WriteLine("There are no monsters to fight in this room.");
            return;
        }

        Monster monster = Monsters[0]; // Pick the first monster in the list
        Console.WriteLine($"You are fighting a {monster.Name}!");
        // You can implement turn-based combat logic here
    }
}
