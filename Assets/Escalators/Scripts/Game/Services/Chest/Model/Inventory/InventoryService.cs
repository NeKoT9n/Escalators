using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Inventory
{
    public class InventoryService : IInventoryService
    {      
        public IReactiveCommand<IReadOnlyInventoryGrid> Registered => _registered;

        private readonly ReactiveCommand<IReadOnlyInventoryGrid> _registered = new();

        private readonly Dictionary<InventoryTypeId, CellGrid> _inventories = new();

        public void RegisterInventory(CellGrid inventory)
        {
            _inventories.Add(inventory.Id, inventory);
            _registered.Execute(inventory);
        }

        public IReadOnlyInventoryGrid GetGrid(InventoryTypeId id)
        {
            if (_inventories.TryGetValue(id, out var inventory) == false)
                throw new Exception($"No inventory in registry with id {id}");

            return inventory;
        }

        private CellGrid GetInventory(InventoryTypeId id)
        {
            if (_inventories.TryGetValue(id, out var inventory) == false)
                throw new Exception($"No inventory in registry with id {id}");

            return inventory;
        }

        public bool TryAddItem(InventoryTypeId inventory, Vector2Int cell, Item item)
        {
            return GetInventory(inventory).TryAddItem(cell, item);
        }

        public bool TryAddItem(InventoryTypeId inventory, Item item)
        {
            return GetInventory(inventory).TryAddItem(item);
        }

        public bool TryRemoveItem(InventoryTypeId inventory, Vector2Int position)
        {
            return GetInventory(inventory).TryRemoveItem(position);
        }
    }
}
