using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine;
using Assets.CodeCore.Scripts.Game.Startup.GameStates;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States.Transitions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.TargetFinder;
using System;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States
{
    public class EntityAttackState : TransitionState
    {
        private readonly ITargetFinder _targetFinder;
        private readonly IAttacker _attacker;
        private readonly Entity _model;

        public IObservable<Unit> Fineshed => _fineshed;

        private readonly Subject<Unit> _fineshed = new();

        public EntityAttackState(
            ITargetFinder targetFinder,
            IAttacker attacker, Entity model,
            IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
            _targetFinder = targetFinder;
            _attacker = attacker;
            _model = model;
        }

        public override void Enter()
        {
            base.Enter();

            var target = _targetFinder.Target;

            _attacker.TryAttack(_model, target.Value);

            _fineshed.OnNext(Unit.Default);
        }

    }
}
