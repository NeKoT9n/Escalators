using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using Assets.Escalators.Scripts.Game.Services.Chest.Presenters;
using UniRx;
using UnityEngine;

namespace Inventory
{
    public class CellGrid : IReadOnlyInventoryGrid
    {
        public IReadOnlyInventorySlot[,] Slots => _slots;
        public Vector2Int Size => _data.Size;

        public InventoryTypeId Id => _data.Id;

        public IReactiveCommand<ItemAddCommand> ItemAdded => _itemAdded;

        public IReactiveCommand<ItemRemoveCommand> ItemRemoved => _itemRemoved;

        private readonly CellSlot[,] _slots;
        private readonly InventoryData _data;
        private readonly IItemPlacementRule _acceptRule;

        private readonly ReactiveCommand<ItemRemoveCommand> _itemRemoved = new();
        private readonly ReactiveCommand<ItemAddCommand> _itemAdded = new();

        public CellGrid(InventoryData data, IItemPlacementRule acceptRule)
        {
            _data = data;
            _acceptRule = acceptRule;

            _slots = new CellSlot[Size.x, Size.y];

            for(int i = 0; i< Size.x; i++)
            {
                for(int j = 0; j < Size.y; j++)
                {
                    _slots[i, j] = new CellSlot(data.SlotData, new Vector2Int(i, j));
                }
            }

        }

        public bool IsFull()
        {
            foreach(var slot in _slots)
            {
                if(slot.IsEmpty)
                    return false;
            }

            return true;
        }

        public bool TryAddItem(Vector2Int index, Item item)
        {
            if(IsFull() == true)
                return false;

            if (CanAdd(item) == false)
                return false;

            var cell = _slots[index.x, index.y];

            if (cell.IsEmpty == false)
                return false;

            cell.SetItem(item);

            _itemAdded.Execute(new ItemAddCommand(Id, item, index));

            return true;
        }

        public bool TryAddItem(Item item)
        {
            if(CanAdd(item) == false)
                return false;

            if (TryGetFirstEmptySlot(out var cell) == false)
                return false;

            cell.SetItem(item);
            _itemAdded.Execute(new ItemAddCommand(Id, item, cell.Position));

            return true;
        }

        private bool TryGetFirstEmptySlot(out CellSlot cell)
        {
            cell = null;

            if (IsFull() == true)
                return false;

            foreach (var slot in _slots)
            {
                if (slot.IsEmpty)
                {
                    cell = slot;
                    return true;
                }
            }

            return false;
        }

        public bool TryRemoveItem(Vector2Int position)
        {
            var slot = _slots[position.x, position.y];

            if (slot.IsEmpty)
                return false;

            slot.RemoveItem();
            _itemRemoved.Execute(new ItemRemoveCommand(Id, position));

            return true;
        }

        public Item GetItem(Vector2Int position)
        {
            return _slots[position.x, position.y].Item.Value;
        }

        public bool CanAdd(Vector2Int position, Item item)
        {
            if (_slots[position.x, position.y].IsEmpty == false)
                return false;

            if (_acceptRule.CanAccept(item) == false)
                return false;

            return true;
        }

        public bool CanAdd(Item item)
        {
            return _acceptRule.CanAccept(item);
        }
    }

    public interface IItemPlacementRule
    {
        public bool CanAccept(Item item);
    }

    public class DefaultSlotRule : IItemPlacementRule
    {
        public bool CanAccept(Item item)
        {
            return true;
        }
    }

    public class KeyTypeSlotRule : IItemPlacementRule
    {
        private readonly KeyTypeId _requiredKeyType;

        public KeyTypeSlotRule(KeyTypeId requiredKeyType)
        {
            _requiredKeyType = requiredKeyType;
        }

        public bool CanAccept(Item item)
        {
            return item is Key key && key.Type == _requiredKeyType;
        }
    }
}
