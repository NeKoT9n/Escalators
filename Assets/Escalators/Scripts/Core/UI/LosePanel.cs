using Assets.CodeCore.Scripts.Game.UI.Base;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Escalators.Scripts.Core.UI
{
    public class LosePanel : UIBase
    {
        [SerializeField] private UIButton _playAgainButton;
        [SerializeField] private Image _blockScreen;

        public ReactiveCommand<Unit> PlayAgainButtonPressed => _playAgainButton.Pressed;

        public override void Show()
        {
            base.Show();
            _blockScreen.gameObject.SetActive(true);
        }

        public override void Hide()
        {
            base.Hide();
            _blockScreen.gameObject.SetActive(false);
        }
    }
}
