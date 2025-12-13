using Assets.Escalators.Scripts.Game.Services.Chest.Presenters.Inventory;
using Inventory;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.DragAndDrop
{
    public interface IDragService
    {
        public void StartDrag(Item item, InventoryPresenter inventory, Vector2Int slotPosition);
        public void EndDrag();
        public (Item item, InventoryPresenter sourcePresenter, Vector2Int sourcePosition) Peek();
        
    }

}
