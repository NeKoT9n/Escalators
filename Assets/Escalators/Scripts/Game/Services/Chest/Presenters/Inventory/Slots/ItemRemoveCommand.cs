using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using Inventory;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Presenters
{
    public struct ItemRemoveCommand
    {
        public InventoryTypeId InventoryId;
        public Vector2Int Position;

        public ItemRemoveCommand(InventoryTypeId inventoryId, Vector2Int position)
        {
            InventoryId = inventoryId;
            Position = position;
        }
    }

    public struct ItemAddCommand
    {
        public InventoryTypeId InventoryId;
        public Item Item;
        public Vector2Int Position;

        public ItemAddCommand(InventoryTypeId inventoryId, Item item, Vector2Int position)
        {
            InventoryId = inventoryId;
            Item = item;
            Position = position;
        }
    }
}
