using Assets.CodeCore.Scripts.Game.UI.Base;
using UniRx;
using UnityEngine;

namespace Assets.Escalators.Scripts.Core.UI
{
    public class WinPanel : UIBase
    {
        [SerializeField] private UIButton _playAgainButton;

        public ReactiveCommand<Unit> PlayAgainButtonPressed => _playAgainButton.Pressed;
    }
}
