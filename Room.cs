namespace DungeonExplorer
{
    // The Room class represents a location in the dungeon where the player can explore.
    public class Room
    {
        // Private fields to store the room's description and the item (if any) in the room.
        private string description;
        private string item;

        // Constructor: Initializes the room with a given description and an optional item.
        public Room(string description, string item = null)
        {
            this.description = description; // Set the room description.
            this.item = item; // Set the item, if provided (default is null).
        }

        // Method to get the description of the room.
        public string GetDescription()
        {
            return description;
        }

        // Method to check if an item is present in the room.
        public string GetItem()
        {
            return item;
        }

        // Method to remove the item from the room and return its name.
        public string RemoveItem()
        {
            string temp = item; // Store the current item.
            item = null; // Remove the item from the room.
            return temp; // Return the removed item.
        }
    }
}
