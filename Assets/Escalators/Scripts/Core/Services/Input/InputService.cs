using Assets.CodeCore.Scripts.Game.Infostracture;
using System;
using UniRx;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture
{
    public class InputService : IInputService, IInitializable, IDisposable
    {
        public IReadOnlyReactiveProperty<Vector2> MoveDirection => _moveDirection;

        private readonly ReactiveProperty<Vector2> _moveDirection;

        private readonly CompositeDisposable _disposables = new();

        public InputService()
        {
            
        }

        public void Initialize()
        {        
            
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
