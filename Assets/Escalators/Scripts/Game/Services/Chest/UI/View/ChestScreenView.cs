using Assets.CodeCore.Scripts.Game.UI.Base;
using DG.Tweening;
using Inventory;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Chest.View.ChestScreen
{
    public class ChestScreenView : UIBase
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private ChestView _chestView;
        [SerializeField] private ItemView _dragItemView;


        public ItemView DragItemView => _dragItemView;
        public InventoryView InventoryView => _inventoryView;
        public ChestView ChestView => _chestView;

        public override void Show()
        {

            base.Show();

            _canvasGroup.alpha = 0;
            transform.localScale = Vector3.one * 0.6f;

            Sequence showSequence = DOTween.Sequence();

            showSequence
                .Append(_canvasGroup.DOFade(1, 0.3f))
                .Join(transform.DOScale(1, 0.3f).SetEase(Ease.OutBack));
        }
    }
}
