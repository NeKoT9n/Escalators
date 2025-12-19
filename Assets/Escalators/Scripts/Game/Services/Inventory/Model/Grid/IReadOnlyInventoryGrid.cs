using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using Assets.Escalators.Scripts.Game.Services.Chest.Presenters;
using UniRx;
using UnityEngine;

namespace Inventory
{
    public interface IReadOnlyInventoryGrid
    {
        public InventoryTypeId Id { get; } 
        public IReadOnlyInventorySlot[,] Slots { get; }
        public Vector2Int Size { get; }
        public bool IsFull();
        public Item GetItem(Vector2Int position);
        public bool CanAdd(Vector2Int position,Item item);
        public IReactiveCommand<ItemAddCommand> ItemAdded { get; }
        public IReactiveCommand<ItemRemoveCommand> ItemRemoved { get; }

    }
}
