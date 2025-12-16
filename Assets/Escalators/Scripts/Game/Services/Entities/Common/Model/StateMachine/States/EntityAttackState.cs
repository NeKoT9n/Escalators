using Assets.CodeCore.Scripts.Game.Startup.GameStates;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.TargetFinder;
using System;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States
{
    public class EntityAttackState : IEnterableState
    {
        private readonly ITargetFinder _targetFinder;
        private readonly IAttacker _attacker;
        private readonly Entity _model;

        public IObservable<bool> Fineshed => _fineshed;

        private readonly Subject<bool> _fineshed = new();

        public EntityAttackState(ITargetFinder targetFinder, IAttacker attacker, Entity model)
        {
            _targetFinder = targetFinder;
            _attacker = attacker;
            _model = model;
        }

        public void Enter()
        {
            var target = _targetFinder.Target;

            _attacker.TryAttack(_model, target.Value);

            _fineshed.OnNext(false);
        }

    }
}
