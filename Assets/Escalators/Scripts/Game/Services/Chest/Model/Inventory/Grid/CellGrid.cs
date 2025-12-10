using UnityEngine;

namespace Inventory
{
    public class CellGrid : IReadOnlyInventoryGrid
    {
        public IReadOnlyInventorySlot[,] Slots => _slots;
        public int Size => _size;

        private readonly int _size; 
        private readonly CellSlot[,] _slots;

        public CellGrid(InventoryData data)
        {
            _size = data.Size;

            _slots = new CellSlot[_size, _size];

            for(int i = 0; i< _size; i++)
            {
                for(int j = 0; j < _size; j++)
                {
                    _slots[i, j] = new CellSlot(data.SlotData);
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

            var cell = _slots[index.x, index.y];

            if (cell.IsEmpty == false)
                return false;

            cell.SetItem(item);

            return true;
        }

        public bool TryAddItem(Item item)
        {
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
    }
}
