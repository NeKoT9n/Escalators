using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Chest.View.ChestScreen;
using Inventory;
using UnityEngine.EventSystems;

namespace Assets.Escalators.Scripts.Game.Services.DragAndDrop
{
    public class DragService : IDragService, IUpdatable
    {
        private readonly ItemView _dragItemView;

        private Item _current = null;
        public DragService(ChestScreenView chestScreenView)
        {
            var inventory = chestScreenView.InventoryView;
            _dragItemView = inventory.DragItemView;

            _dragItemView.Hide();
        }

        public void StartDrag(Item item)
        {
            _current = item;
            _dragItemView.SetIcon(item.Icon);
            _dragItemView.Show();
        }

        public void Update()
        {
           
        }

        public Item EndDrag()
        {
            _dragItemView.Hide();

            var item = _current;
            _current = null;

            return item;
        }


    }
}
