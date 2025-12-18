using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine;
using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine.States.Interfaces;
using Assets.CodeCore.Scripts.Game.Startup.GameStates;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.TargetFinder;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.View;
using Cysharp.Threading.Tasks;
using UnityEngine;


namespace Assets.Escalators.Scripts.Game.Services.Entities.EnemyLogic.Model
{
    public class EnemyStateMachine : GameStateMachine
    {
    }

    public class EnemyIdleState : IUpdatableState
    {
        private readonly TargetFinder _targetFinder;
        private readonly IStateSwitcher _stateSwitcher;

        public EnemyIdleState(TargetFinder targetFinder, IStateSwitcher stateSwitcher)
        {
            _targetFinder = targetFinder;
            _stateSwitcher = stateSwitcher;
        }

        public void Update()
        {
            _targetFinder.FindTarget();
            var target = _targetFinder.Target.Value;

            if (target != null)
            {
                _stateSwitcher.TrySwitchState<EnemyChaseState>();
            }
        }

        public class EnemyChaseState : IEnterableState, IUpdatableState, IExitableState
        {
            private readonly ITargetFinder _targetFinder;
            private readonly IMover _mover;
            private readonly Entity _model;
            private readonly IStateSwitcher _stateSwitcher;

            private EntityView _target;

            public EnemyChaseState(
                ITargetFinder targetFinder,
                IMover mover,
                Entity model,
                IStateSwitcher stateSwitcher)
            {
                _targetFinder = targetFinder;
                _mover = mover;
                _model = model;
                _stateSwitcher = stateSwitcher;
            }

            public void Enter()
            {
                _target = _targetFinder.Target.Value;
                _mover.LookAt(_target.transform.position);
            }

            public void Update()
            {
                
                if (_target == null || !_target.gameObject.activeSelf)
                {
                    _stateSwitcher.TrySwitchState<EnemyIdleState>();
                    return;
                }

                float distance = Vector3
                    .Distance(_model.Position.Value, _target.transform.position);

                if (distance <= _model.AttackRange)
                {
                    _stateSwitcher.TrySwitchState<EnemyAttackState>();
                }
                else
                {
                    _mover.Move();
                }
            }

            public void Exit()
            {
                _mover.Stop();
            }
        }

        public class EnemyAttackState : IEnterableState
        {
            private readonly IAttacker _attacker;
            private readonly IMover _mover;
            private readonly ITargetFinder _targetFinder;
            private readonly IStateSwitcher _stateSwitcher;
            private EntityView _target;

            public EnemyAttackState(
                IAttacker attacker,
                IMover mover,
                ITargetFinder targetFinder,
                IStateSwitcher stateSwitcher)
            {
                _attacker = attacker;
                _mover = mover;
                _targetFinder = targetFinder;
                _stateSwitcher = stateSwitcher;
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

                _stateSwitcher.TrySwitchState<EnemyIdleState>();
            }

        }
    }
}
