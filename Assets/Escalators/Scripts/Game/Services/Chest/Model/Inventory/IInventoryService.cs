using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using UniRx;
using UnityEngine;

namespace Inventory
{
    public interface IInventoryService
    {
        public IReactiveCommand<IReadOnlyInventoryGrid> Registered { get; }
        public void RegisterInventory(CellGrid inventory);
        public IReadOnlyInventoryGrid GetGrid(InventoryTypeId id);
        public bool TryAddItem(InventoryTypeId inventory, Vector2Int cell, Item item);
        public bool TryAddItem(InventoryTypeId inventory, Item item);
        public bool TryRemoveItem(InventoryTypeId inventory, Vector2Int position);
    }
}
