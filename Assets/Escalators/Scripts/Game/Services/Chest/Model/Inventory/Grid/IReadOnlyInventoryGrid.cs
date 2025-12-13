using UnityEngine;

namespace Inventory
{
    public interface IReadOnlyInventoryGrid
    {
        public IReadOnlyInventorySlot[,] Slots { get; }
        public int Size { get; }
        public bool IsFull();
        public Item GetItem(Vector2Int position);
        public bool CanAdd(Vector2Int position,Item item);
    }
}
