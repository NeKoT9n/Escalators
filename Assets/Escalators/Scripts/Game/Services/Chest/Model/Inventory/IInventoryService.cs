using UnityEngine;

namespace Inventory
{
    public interface IInventoryService
    {
        public IReadOnlyInventoryGrid Grid { get; }
        public bool TryAddItem(Vector2Int cell, Item item);
        public bool TryAddItem(Item item);
        public bool TryRemoveItem(Vector2Int position);
    }
}
