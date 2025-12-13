using Assets.CodeCore.Scripts.Game.Infostracture;
using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture
{
    public class InputService : IInputService, IInitializable,IUpdatable, IDisposable
    {
        public IReadOnlyReactiveProperty<Vector2> MoveDirection => _moveDirection;

        public Vector2 MousePosition => _mousePosition;

        private readonly ReactiveProperty<Vector2> _moveDirection = new();
        private Vector2 _mousePosition = Vector2.zero;

        private readonly Joystick _joystick;
        private readonly CompositeDisposable _disposables = new();

        private readonly InputSystem_Actions _inputActions = new();

        public InputService(Joystick joystick)
        {
            _joystick = joystick;
        }

        public void Initialize()
        {
            _inputActions.Player.Enable();
            _inputActions.UI.Enable();

            _inputActions.UI.Point.performed += context 
                => _mousePosition = context.ReadValue<Vector2>();
        }

        public void Update()
        {
            _moveDirection.Value = _joystick.Direction;
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }


    }
}
