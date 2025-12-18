using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine;
using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine.States.Interfaces;
using Assets.CodeCore.Scripts.Game.Startup.GameStates;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.TargetFinder;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.View;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Model
{
    public class PlayerStateMachine : GameStateMachine
    {
    }

    public class PlayerMoveState : IUpdatableState, IExitableState
    {

        private readonly IMover _mover;
        private readonly IInputService _inputService;
        private readonly IStateSwitcher _stateSwitcher;

        public PlayerMoveState(
            IMover mover,
            IInputService inputService,
            IStateSwitcher stateSwitcher)
        {
            _mover = mover;
            _inputService = inputService;
            _stateSwitcher = stateSwitcher;
        }

        public void Update()
        {

            if (_inputService.MoveDirection.Value == Vector2.zero)
            {
                _stateSwitcher.TrySwitchState<PlayerFindTargetState>();
                return;
            }

            _mover.Move();
        }

        public void Exit()
        {
            _mover.Stop();
        }
    }

    public class PlayerFindTargetState : IUpdatableState
    {
        private readonly IInputService _inputService;
        private readonly ITargetFinder _targetFinder;
        private readonly IStateSwitcher _stateSwitcher;

        public PlayerFindTargetState(
            IInputService inputService,
            ITargetFinder targetFinder,
            IStateSwitcher stateSwitcher)
        {
            _inputService = inputService;
            _targetFinder = targetFinder;
            _stateSwitcher = stateSwitcher;
        }

        public void Update()
        {
            if (_inputService.MoveDirection.Value != Vector2.zero)
            {
                _stateSwitcher.TrySwitchState<PlayerMoveState>();
                return;
            }


            _targetFinder.FindTarget();

            var target = _targetFinder.Target.Value;

            if (target != null)
            {
                _stateSwitcher.TrySwitchState<PlayerAttackState>();
            }
        }
    }

    public class PlayerAttackState : IEnterableState
    {
        private readonly IAttacker _attacker;
        private readonly IMover _mover;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly ITargetFinder _targetFinder;

        private EntityView _target; 

        public PlayerAttackState(
            IAttacker attacker,
            IMover mover,
            IStateSwitcher stateSwitcher,
            ITargetFinder targetFinder)
        {
            _attacker = attacker;
            _mover = mover;
            _stateSwitcher = stateSwitcher;
            _targetFinder = targetFinder;
        }

        public void Enter()
        {
            _target = _targetFinder.Target.Value;
            _mover.LookAt(_target.transform.position);

            ProcessAttack().Forget();
        }

        private async UniTaskVoid ProcessAttack()
        {

            await _attacker.TryAttack(_target);

            _stateSwitcher.TrySwitchState<PlayerFindTargetState>();
        }
   
    }


}
