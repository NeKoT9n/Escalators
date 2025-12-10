using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Chest.Presenters.Inventory;
using Assets.Escalators.Scripts.Game.Services.Chest.View;
using Assets.Escalators.Scripts.Game.Services.Chest.View.ChestScreen;
using Inventory;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Presenters
{
    public class ChestScreenPresenter : IInitializable
    {
        private readonly IInventoryService _inventoryService;
        private readonly ChestScreenView _chestScreenView;
        private readonly InventorySlotViewFactory _slotViewFactory;

        public ChestScreenPresenter(
            IInventoryService inventoryService,
            ChestScreenView chestScreenView,
            InventorySlotViewFactory slotViewFactory)
        {
            _inventoryService = inventoryService;
            _chestScreenView = chestScreenView;
            _slotViewFactory = slotViewFactory;
        }

        public void Initialize()
        {
            var grid = _inventoryService.Grid;
            var view = _chestScreenView.InventoryView;

            InventoryPresenter presenter = new(grid, view, _slotViewFactory);
            presenter.Initialize();
        }
    }
}
