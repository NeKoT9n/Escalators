using Assets.CodeCore.Scripts.Game.UI.Base;
using UnityEngine;

namespace Inventory
{
    public class InventoryView : UIBase
    {
        [SerializeField] private Transform _grid; 

        public void AddSlot(SlotView slotView)
        {
            slotView.transform.SetParent(_grid);
        }
    }
}
