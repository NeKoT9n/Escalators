using UnityEngine;

namespace Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private Transform _grid; 
        [SerializeField] private ItemView _dragItemView; 

        public ItemView DragItemView => _dragItemView;

        public void AddSlot(SlotView slotView)
        {
            slotView.transform.SetParent(_grid);
        }
    }
}
