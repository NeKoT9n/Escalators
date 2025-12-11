using Inventory;
using UnityEngine.EventSystems;

namespace Assets.Escalators.Scripts.Game.Services.DragAndDrop
{
    public interface IDragService
    {
        public void StartDrag(Item item);
        public Item EndDrag();
        
    }
}
