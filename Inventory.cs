namespace DungeonExplorer
{
    // Inventory class manages a list of items a player can carry
    public class Inventory
    {
        // Private list to store items
        private List<Item> items;

        // Constructor initializes the item list
        public Inventory()
        {
            items = new List<Item>();
        }

        // Adds an item to the inventory
        public void AddItem(Item item)
        {
            items.Add(item);
        }

        // Removes an item from the inventory
        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        // Returns the list of all items in the inventory
        public List<Item> GetItems()
        {
            return items;
        }

        // Returns a formatted string of item names in the inventory
        public string GetInventoryList()
        {
            if (items.Count == 0) return "Inventory is empty.";
            return "Inventory: " + string.Join(", ", items.Select(i => i.Name));
        }
    }
}
