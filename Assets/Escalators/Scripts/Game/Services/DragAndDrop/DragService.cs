using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using Assets.Escalators.Scripts.Game.Services.Chest.View.ChestScreen;
using Inventory;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.DragAndDrop
{
    public class DragService : IDragService, IUpdatable
    {
        public bool IsDragging { get; private set; }

        private readonly IInputService _inputService;

        private readonly ItemView _dragItemView;

        private DragInformation? _current;

        public DragService(ChestScreenView chestScreenView, IInputService inputService)
        {
            _dragItemView = chestScreenView.DragItemView;

            _dragItemView.Hide();
            _inputService = inputService;
        }

        public void StartDrag(DragInformation dragInformation)
        {
            if (dragInformation.IsEmpty)
                return;

            IsDragging = true;

            _current = dragInformation;

            ShowView(_current?.Item);
        }
        public void Update()
        {
            _dragItemView.transform.position = _inputService.MousePosition;
        }

        public DragInformation? Peek()
        {
            return _current;
        }

        public void EndDrag()
        {
            IsDragging = false;
            _current = null;

            _dragItemView.Hide();
        }

        private void ShowView(Item item)
        {
            _dragItemView.SetIcon(item.Icon);
            _dragItemView.Show();
        }
    }

    public struct DragInformation
    {
        public InventoryTypeId InventoryId;
        public Item Item;
        public Vector2Int SlotPosition;

        public DragInformation(InventoryTypeId inventoryId, Item item, Vector2Int slotPosition)
        {
            InventoryId = inventoryId;
            Item = item;
            SlotPosition = slotPosition;
        }

        public readonly bool IsEmpty => Item == null;
    }
}
