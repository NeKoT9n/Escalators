namespace Inventory
{
    public interface IReadOnlyInventoryGrid
    {
        public IReadOnlyInventorySlot[,] Slots { get; }
        public int Size { get; }
    }
}
