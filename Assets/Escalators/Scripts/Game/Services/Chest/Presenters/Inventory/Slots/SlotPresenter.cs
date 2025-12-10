using Assets.CodeCore.Scripts.Game.Infostracture;
using Inventory;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Presenters
{
    public class SlotPresenter : IInitializable
    {
        private readonly IReadOnlyInventorySlot _cellSlot;
        private readonly SlotView _slotView;

        private readonly CompositeDisposable _disposables = new();

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
}
