using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine.States.Interfaces;
using Assets.CodeCore.Scripts.Game.Startup.GameStates;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using System;
using UniRx;
using UnityEngine;


namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States
{
    public class PlayerMoveState : IEnterableState, IUpdatableState, IExitableState
    {
        private readonly IInputService _inputService;
        private readonly Entity _entity;
        private readonly IMover _mover;

        private readonly Subject<Unit> _stoped = new();
        public IObservable<Unit> Stoped => _stoped;
        public PlayerMoveState(IInputService inputService, Entity entity, IMover mover)
        {
            _inputService = inputService;
            _entity = entity;
            _mover = mover;

        }
        public void Enter()
        {
            _entity.IsMoving.Value = true;
        }

        public void Update()
        {
            var direction = _inputService.MoveDirection.Value;

            if (direction.sqrMagnitude < 0.01f)
                _stoped.OnNext(Unit.Default);

            _mover.Move(_entity, direction, Time.deltaTime);
        }

        public void Exit()
        {
            _entity.IsMoving.Value = false;
        }

    }
}
