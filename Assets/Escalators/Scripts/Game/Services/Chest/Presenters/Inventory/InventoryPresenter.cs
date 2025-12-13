using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Chest.Presenters.Inventory.Slots;
using Assets.Escalators.Scripts.Game.Services.Chest.View;
using Inventory;
using UniRx;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Escalators.Scripts.Game.Services.DragAndDrop;


namespace Assets.Escalators.Scripts.Game.Services.Chest.Presenters.Inventory
{
    public class InventoryPresenter : IInitializable, IDisposable
    {
        private readonly IReadOnlyInventoryGrid _cellGrid;
        private readonly InventoryView _inventoryView;

        private readonly InventorySlotViewFactory _slotViewFactory;
        private readonly InventorySlotPresenterFactory _slotPresenterFactory;
        private readonly IDragService _dragService;
        private readonly List<SlotPresenter> _slots = new();

        public ReactiveCommand<Vector2Int> RemoveCommand = new();
        public ReactiveCommand<ItemAddCommand> AddCommand = new();

        private readonly CompositeDisposable _disposables = new();

        public InventoryPresenter(
            IReadOnlyInventoryGrid cellGrid, 
            InventoryView inventoryView,
            InventorySlotViewFactory slotViewFactory,
            InventorySlotPresenterFactory slotPresenterFactory,
            IDragService dragService)
        {
            _cellGrid = cellGrid;
            _inventoryView = inventoryView;
            _slotViewFactory = slotViewFactory;
            _slotPresenterFactory = slotPresenterFactory;
            _dragService = dragService;
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

            presenter.DragBegining
                .Subscribe(_ => OnDragBegin(presenter))
                .AddTo(_disposables);
            
            presenter.DragEnded
                .Subscribe(_ => OnEndDrag())
                .AddTo(_disposables);

            presenter.Droped
                .Subscribe(eventData => OnDrop(presenter))
                .AddTo(_disposables);
        }

        private void OnDragBegin(SlotPresenter presenter)
        {
            var position = presenter.Position;
            var item = _cellGrid.GetItem(position);

            _dragService.StartDrag(item, this, position);

        }
        private void OnEndDrag()
        {        
            _dragService.EndDrag();
        }

        private void OnDrop(SlotPresenter presenter)
        {
            var droppedItemInfo = _dragService.Peek();
            var item = droppedItemInfo.item;

            if (item != null)
            {
                var sourcePresenter = droppedItemInfo.sourcePresenter;
                var sourcePosition = droppedItemInfo.sourcePosition;

                if (_cellGrid.CanAdd(presenter.Position, item) == false)
                    return;

                sourcePresenter.RemoveCommand
                    .Execute(sourcePosition);

                AddCommand.Execute(new()
                {
                    Item = item,
                    Position = presenter.Position,
                });  
            }
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
