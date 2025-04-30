using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    // GameMap class handles the collection of rooms and interactions with them
    public class GameMap
    {
        // Private dictionary to store rooms, with room names as keys
        private Dictionary<string, Room> rooms;

        // Constructor initializes the rooms dictionary
        public GameMap()
        {
            rooms = new Dictionary<string, Room>();
            // Initialize rooms here with names and room objects

            // Add more rooms if needed and connect them as required
        }

        // Adds or updates a room in the map with the given name and room object
        public void AddRoom(string name, Room room)
        {
            rooms[name] = room;
        }

        // Retrieves a room by its name. Returns null if the room is not found.
        public Room? GetRoom(string name)
        {
            rooms.TryGetValue(name, out Room? room); // Safely tries to get the room
            return room;
        }

        // Returns a list of all room names in the map
        public List<string> GetRoomNames()
        {
            return rooms.Keys.ToList(); // Converts the keys (room names) to a list
        }

        // Returns the starting room (the first room added to the map)
        public Room GetStartingRoom()
        {
            return rooms.Values.First(); // Returns the first room as the starting point
        }
    }
}