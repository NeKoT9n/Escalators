using Assets.CodeCore.Scripts.Game.Infostracture;
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
        private readonly CompositeDisposable _disposables = new();

        public Vector2Int Position => _cellSlot.Position;

        public ReactiveCommand<PointerEventData> DragBegining => _slotView.DragBegining;
        public ReactiveCommand<PointerEventData> DragEnded => _slotView.DragEnded;
        public ReactiveCommand<PointerEventData> Droped => _slotView.Droped;

        public SlotView SlotView => _slotView;

        public SlotPresenter(
            IReadOnlyInventorySlot cellSlot,
            SlotView slotView)
        {
            _cellSlot = cellSlot;
            _slotView = slotView;         
        }

        public void Initialize()
        {
            _cellSlot.Item
                .Subscribe(item => OnItemChanched(item))
                .AddTo(_disposables);
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
        public SlotView GetTargetView(PointerEventData eventData)
        {
            var gameObject = eventData.pointerCurrentRaycast.gameObject;

            if (gameObject != null && gameObject.TryGetComponent(out SlotView target))
                return target;

            return null;
        }
    }

    public struct ItemAddCommand
    {
        public Item Item;
        public SlotPresenter Sender;
        public Vector2Int Position;

    }
}
