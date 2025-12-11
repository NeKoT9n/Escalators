using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Chest.Presenters.Inventory;
using Assets.Escalators.Scripts.Game.Services.Chest.View.ChestScreen;
using Inventory;
using System;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Presenters
{
    public class ChestScreenPresenter : IInitializable, IDisposable
    {
        private readonly IInventoryService _inventoryService;
        private readonly ChestScreenView _chestScreenView;
        private readonly InventoryPresenterFactory _inventoryPresenterFactory;

        private InventoryPresenter _presenter;

        private CompositeDisposable _disposables = new();

        public ChestScreenPresenter(
            IInventoryService inventoryService,
            ChestScreenView chestScreenView,
            InventoryPresenterFactory inventoryPresenterFactory)
        {
            _inventoryService = inventoryService;
            _chestScreenView = chestScreenView;
            _inventoryPresenterFactory = inventoryPresenterFactory;
        }

        public void Initialize()
        {
            var grid = _inventoryService.Grid;
            var view = _chestScreenView.InventoryView;

            _presenter = _inventoryPresenterFactory.Create(grid, view);
            _presenter.Initialize();

            _presenter.RemoveCommand
                .Subscribe(position => _inventoryService.TryRemoveItem(position))
                .AddTo(_disposables);

            _presenter.AddCommand
                .Subscribe(command => _inventoryService.TryAddItem(command.Position, command.Item))
                .AddTo(_disposables);
        }
        public void Dispose()
        {
            _presenter.Dispose();
            _disposables.Dispose();
        }
    }
}
