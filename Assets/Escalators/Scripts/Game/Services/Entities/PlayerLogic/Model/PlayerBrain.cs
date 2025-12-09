using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Startup.GameStates;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States;
using System.Collections.Generic;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic
{
    public class PlayerBrain : Brain, IInitializable
    {
        private readonly PlayerStateMachine _playerStateMachine = new();

        private readonly PlayerMoveState _moveState;
        private readonly PlayerFindTargetState _findTargetState;
        private readonly EntityAttackState _attackState;
        private readonly IInputService _inputService;
        private readonly CompositeDisposable _disposables = new();

        public PlayerBrain(
            PlayerMoveState playerMoveState,
            PlayerFindTargetState playerFindTargetState,
            EntityAttackState entityAttackState)
        {

            _moveState = playerMoveState;
            _findTargetState = playerFindTargetState;
            _attackState = entityAttackState;
        }

        public void Initialize()
        {
            _playerStateMachine.Initialize(new List<IState>()
            {
                _findTargetState,
                _moveState,
                _attackState
            });

            _moveState.Stoped
                .Subscribe(_ => _playerStateMachine.TrySwitchState<PlayerFindTargetState>())
                .AddTo(_disposables);

            _findTargetState.Finded
                .Subscribe(_ => _playerStateMachine.TrySwitchState<EntityAttackState>())
                .AddTo(_disposables);

            _findTargetState.Moved
                .Subscribe(_ => _playerStateMachine.TrySwitchState<PlayerMoveState>())
                .AddTo(_disposables);

            _playerStateMachine.TrySwitchState<PlayerFindTargetState>();
        }

        public override void Update() 
        {
            _playerStateMachine?.Update();
        }

    }
}
