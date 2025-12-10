using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private Transform _grid; 

        public void AddSlot(SlotView slotView)
        {
            slotView.transform.SetParent(_grid);
        }
    }
}
