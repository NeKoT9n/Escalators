using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine.States.Interfaces;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.TargetFinder;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.View;
using System;
using UniRx;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States
{
    public class PlayerFindTargetState : IUpdatableState, IDisposable
    {
        public IObservable<EntityView> Finded => _finded;
        public IObservable<Unit> Moved => _moved;

        private readonly Subject<Unit> _moved = new();
        private readonly Subject<EntityView> _finded = new();

        private readonly ITargetFinder _targetFinder;
        private readonly IInputService _inputService;
        private readonly Entity _entity;

        private readonly IDisposable _disposable;

        public PlayerFindTargetState(
            ITargetFinder targetFinder,
            IInputService inputService,
            Entity entity)
        {
            _targetFinder = targetFinder;
            _inputService = inputService;
            _entity = entity;

            _disposable = _targetFinder.Target
                .Subscribe(target => HandleTarget(target));
        }

        public void Update()
        {
            Debug.Log(_inputService.MoveDirection.Value);

            if(_inputService.MoveDirection.Value != Vector2.zero)
            {
                _moved.OnNext(Unit.Default);
            }

            _targetFinder.FindTarget(_entity.Position.Value,  _entity.AttackRange);      
        }

        private void HandleTarget(EntityView target)
        {
            if(target == null) 
                return;

            _finded.OnNext(target);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
