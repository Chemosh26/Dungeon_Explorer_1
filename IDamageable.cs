namespace DungeonExplorer
{
    // Interface that defines the contract for objects that can take damage
    public interface IDamageable
    {
        // Method to handle taking damage, reduces health by the specified amount
        void TakeDamage(int amount);

        // Method to check if the object is still alive (i.e., has health remaining)
        bool IsAlive();
    }
}
