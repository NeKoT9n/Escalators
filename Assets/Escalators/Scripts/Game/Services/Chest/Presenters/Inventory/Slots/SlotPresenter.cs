using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.DragAndDrop;
using Inventory;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Presenters
{
    public class SlotPresenter : IInitializable
    {
        private readonly IReadOnlyInventorySlot _cellSlot;
        private readonly SlotView _slotView;
        private readonly IDragService _dragService;
        private readonly InventoryDragHandler _inventoryDragHandler;
        private readonly CompositeDisposable _disposables = new();

        public ReactiveCommand<SlotPresenter> RemoveCommand = new();
        public ReactiveCommand<ItemAddCommand> AddCommand = new();

        public SlotPresenter(
            IReadOnlyInventorySlot cellSlot,
            SlotView slotView,
            IDragService dragService,
            InventoryDragHandler inventoryDragHandler)
        {
            _cellSlot = cellSlot;
            _slotView = slotView;
            _dragService = dragService;
            _inventoryDragHandler = inventoryDragHandler;
        }

        public void Initialize()
        {
            _cellSlot.Item
                .Subscribe(item => OnItemChanched(item))
                .AddTo(_disposables);

            _slotView.DragBegining
                .Subscribe(eventData => OnDragBegining(eventData))
                .AddTo(_disposables);

            _slotView.DragEnded
                .Subscribe(eventData => OnDragEnded(eventData))
                .AddTo(_disposables);

            _slotView.DragHandled
                .Subscribe(_ => TryAddItem())
                .AddTo(_disposables);

        }

        private void TryAddItem()
        {
            var item = _dragService.EndDrag();

            if (item == null)
                return;

            AddCommand.Execute(new ItemAddCommand()
            {
                Item = item,
                Sender = this,
                Position = Vector2Int.zero
            });
        }

        private void OnDragBegining(PointerEventData _)
        {
            if (_cellSlot.IsEmpty)
                return;

            _dragService.StartDrag(_cellSlot.Item.Value);
        }

        private void OnDragEnded(PointerEventData eventData)
        {
            var result = _inventoryDragHandler.Handle(eventData);

            if (result == false)
            {
                _dragService.EndDrag();
                return;
            }

            RemoveCommand.Execute(this);
        }

        private void OnItemChanched(Item item)
        {
            if (item == null)
            {
                _slotView.Clear();
                return;
            }

            _slotView.SetIcon(item.Icon);
            _slotView.SetDescription(item.Description);
        }

    }

    public class InventoryDragHandler
    {
        public bool Handle(PointerEventData eventData)
        {
            var gameObject = eventData.pointerCurrentRaycast.gameObject;

            if (gameObject == null)
                return false;

            if(gameObject.TryGetComponent(out SlotView target) == false)
                return false;

            if(target.IsEmpty == false)
                return false;

            target.OnDragHandled();

            return true;
        }
    }

    public struct ItemAddCommand
    {
        public Item Item;
        public SlotPresenter Sender;
        public Vector2Int Position;

    }
}
