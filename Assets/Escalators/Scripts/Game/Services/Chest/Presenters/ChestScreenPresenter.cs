using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
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

        private InventoryPresenter _playerPresenter;
        private InventoryPresenter _chestPresenter;

        private readonly CompositeDisposable _disposables = new();

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
            _inventoryService.Registered.Subscribe(inventory =>
                {
                    switch (inventory.Id) 
                    {
                        case InventoryTypeId.Player:
                            CreatePlayerInventory(inventory);
                            return;
                        case InventoryTypeId.Chest:
                            CreateChestInventory(inventory);
                            return;
                    }
                })
                .AddTo(_disposables);

        }

        private void CreatePlayerInventory(IReadOnlyInventoryGrid grid)
        {
            var playerInventoryView = _chestScreenView.InventoryView;

            _playerPresenter = CreateInventory(grid, playerInventoryView);
        }

        private void CreateChestInventory(IReadOnlyInventoryGrid grid)
        { 
            var chestInventoryView = _chestScreenView.ChestView.InventoryView;

            _chestPresenter = CreateInventory(grid, chestInventoryView);
        }

        private InventoryPresenter CreateInventory(IReadOnlyInventoryGrid grid, InventoryView view)
        {         
            
            var presenter = _inventoryPresenterFactory.Create(grid, view);
            presenter.Initialize();

            presenter.RemoveCommand
                .Subscribe(command 
                        => _inventoryService.TryRemoveItem(command.InventoryId, command.Position))
                .AddTo(_disposables);

            presenter.AddCommand
                .Subscribe(command
                        => _inventoryService.TryAddItem(command.InventoryId, command.Position, command.Item))
                .AddTo(_disposables);

            return presenter;
        }

        public void Dispose()
        {
            _chestPresenter.Dispose();
            _playerPresenter.Dispose();

            _disposables.Dispose();
        }
    }
}
