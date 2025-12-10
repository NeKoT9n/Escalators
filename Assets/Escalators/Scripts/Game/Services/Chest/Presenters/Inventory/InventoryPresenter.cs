using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Chest.View;
using Inventory;
using System.Collections.Generic;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Presenters.Inventory
{
    public class InventoryPresenter : IInitializable
    {
        private readonly IReadOnlyInventoryGrid _cellGrid;
        private readonly InventoryView _inventoryView;
        private readonly InventorySlotViewFactory _slotViewFactory;

        private readonly List<SlotPresenter> _slots = new();

        public InventoryPresenter(
            IReadOnlyInventoryGrid cellGrid, 
            InventoryView inventoryView,
            InventorySlotViewFactory slotViewFactory)
        {
            _cellGrid = cellGrid;
            _inventoryView = inventoryView;
            _slotViewFactory = slotViewFactory;
        }

        public void Initialize()
        {
            foreach (var slot in _cellGrid.Slots)
            {
                CreateSlot(slot);
            }
        }

        public async void CreateSlot(IReadOnlyInventorySlot slot)
        {
            SlotView view = await _slotViewFactory.Create(slot);
            _inventoryView.AddSlot(view);

            SlotPresenter presenter = new(slot, view);
            presenter.Initialize();

            _slots.Add(presenter);
        }


    }
}
