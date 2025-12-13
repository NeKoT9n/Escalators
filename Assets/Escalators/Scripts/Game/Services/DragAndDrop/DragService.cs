using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Chest.Presenters.Inventory;
using Assets.Escalators.Scripts.Game.Services.Chest.View.ChestScreen;
using Inventory;
using UnityEngine;


namespace Assets.Escalators.Scripts.Game.Services.DragAndDrop
{
    public class DragService : IDragService, IUpdatable
    {
        private readonly ItemView _dragItemView;
        private readonly IInputService _inputService;
        private Item _current = null;
        private InventoryPresenter _sourcePresenter = null;
        private Vector2Int _sourcePosition = Vector2Int.zero;

        public bool IsDragging { get; private set; }
        public DragService(ChestScreenView chestScreenView, IInputService inputService)
        {
            var inventory = chestScreenView.InventoryView;
            _dragItemView = inventory.DragItemView;

            _dragItemView.Hide();
            _inputService = inputService;
        }


        public void StartDrag(Item item, InventoryPresenter inventory, Vector2Int slotPosition)
        {
            if (item == null)
                return;

            IsDragging = true;
            _current = item;
            _sourcePresenter = inventory;
            _sourcePosition = slotPosition;

            ShowView(item);
        }
        public void Update()
        {
            _dragItemView.transform.position = _inputService.MousePosition;
        }

        public (Item item, InventoryPresenter sourcePresenter, Vector2Int sourcePosition) Peek()
        {
            return (_current, _sourcePresenter, _sourcePosition);
        }

        public void EndDrag()
        {
            IsDragging = false;
            _current = null;
            _sourcePresenter = null;
            _dragItemView.Hide();
        }

        private void ShowView(Item item)
        {
            _dragItemView.SetIcon(item.Icon);
            _dragItemView.Show();
        }


    }
}
