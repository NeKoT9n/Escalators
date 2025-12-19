using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeCore.Scripts.Game.UI.Base
{
    [RequireComponent(typeof(Button))]
    public class UIButton : UIBase
    {
        private Button _button;
        public ReactiveCommand<Unit> Pressed { get; private set; } = new();

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(() => Pressed.Execute(Unit.Default));
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(() => Pressed.Execute(Unit.Default));
        }

    }
}
