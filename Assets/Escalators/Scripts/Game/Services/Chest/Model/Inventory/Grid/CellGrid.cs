using UnityEngine;

namespace Inventory
{
    public class CellGrid : IReadOnlyInventoryGrid
    {
        public IReadOnlyInventorySlot[,] Slots => _slots;
        public int Size => _size;

        private readonly int _size; 
        private readonly CellSlot[,] _slots;
        private readonly IItemPlacementRule _acceptRule;

        public CellGrid(InventoryData data, IItemPlacementRule acceptRule)
        {
            _size = data.Size;

            _slots = new CellSlot[_size, _size];

            for(int i = 0; i< _size; i++)
            {
                for(int j = 0; j < _size; j++)
                {
                    _slots[i, j] = new CellSlot(data.SlotData, new Vector2Int(i, j));
                }
            }

            _acceptRule = acceptRule;
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

            return true;
        }

        public bool TryAddItem(Item item)
        {
            if(CanAdd(item) == false)
                return false;

            if (TryGetFirstEmptySlot(out var cell) == false)
                return false;

            cell.SetItem(item);

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
