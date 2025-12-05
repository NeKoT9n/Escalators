using Assets.CodeCore.Scripts.Game.Infostracture;
using System;
using UniRx;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture
{
    public class InputService : IInputService, IInitializable, IDisposable
    {
        public IReadOnlyReactiveProperty<Vector2> MoveDirection => _moveDirection;

        private readonly ReactiveProperty<Vector2> _moveDirection = new();

        private readonly Joystick _joystick;
        private readonly CompositeDisposable _disposables = new();

        public InputService(Joystick joystick)
        {
            _joystick = joystick;
        }

        public void Initialize()
        {
            Observable
                .EveryUpdate()
                .Subscribe(_ => _moveDirection.Value = _joystick.Direction)
                .AddTo(_disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
