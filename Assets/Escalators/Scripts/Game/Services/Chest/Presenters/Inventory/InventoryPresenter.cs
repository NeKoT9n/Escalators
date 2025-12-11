using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Chest.Presenters.Inventory.Slots;
using Assets.Escalators.Scripts.Game.Services.Chest.View;
using Inventory;
using UniRx;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Presenters.Inventory
{
    public class InventoryPresenter : IInitializable, IDisposable
    {
        private readonly IReadOnlyInventoryGrid _cellGrid;
        private readonly InventoryView _inventoryView;

        private readonly InventorySlotViewFactory _slotViewFactory;
        private readonly InventorySlotPresenterFactory _slotPresenterFactory;
        private readonly List<SlotPresenter> _slots = new();

        public ReactiveCommand<Vector2Int> RemoveCommand = new();
        public ReactiveCommand<ItemAddCommand> AddCommand = new();

        private readonly CompositeDisposable _disposables = new();

        public InventoryPresenter(
            IReadOnlyInventoryGrid cellGrid, 
            InventoryView inventoryView,
            InventorySlotViewFactory slotViewFactory,
            InventorySlotPresenterFactory slotPresenterFactory)
        {
            _cellGrid = cellGrid;
            _inventoryView = inventoryView;
            _slotViewFactory = slotViewFactory;
            _slotPresenterFactory = slotPresenterFactory;
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

            SlotPresenter presenter = _slotPresenterFactory.Create(slot, view);
            InitializeSlotPresenter(presenter);

            _slots.Add(presenter);
        }

        private void InitializeSlotPresenter(SlotPresenter presenter)
        {
            presenter.Initialize();

            presenter.RemoveCommand
                .Subscribe(sender => OnRemoveCommand(sender))
                .AddTo(_disposables);

            presenter.AddCommand
                .Subscribe(addCommand => OnAddCommand(addCommand))
                .AddTo(_disposables);
        }

        private void OnAddCommand(ItemAddCommand addCommand)
        {
            int index = _slots.IndexOf(addCommand.Sender);
            var position = GetPositionByIndex(index);

            addCommand.Position = position;

            AddCommand.Execute(addCommand);
        }

        private void OnRemoveCommand(SlotPresenter sender)
        {
            int index = _slots.IndexOf(sender);
            var position = GetPositionByIndex(index);

            RemoveCommand.Execute(position);
        }

        private Vector2Int GetPositionByIndex(int index)
        {
            int i = index / _cellGrid.Size;
            int j = index % _cellGrid.Size;

            return new(i, j);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
