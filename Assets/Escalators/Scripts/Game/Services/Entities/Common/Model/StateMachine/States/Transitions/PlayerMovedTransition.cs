using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.TargetFinder;
using System;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States.Transitions
{
    public class PlayerMovedCondition 
    {
        private readonly IInputService _inputService;

        public PlayerMovedCondition(IInputService inputService)
        {
            _inputService = inputService;
        }

        public IObservable<Unit> IsMoving()
        {
            return _inputService.MoveDirection
                .Where(dir => dir.sqrMagnitude > 0.01f)
                .Select(_ => Unit.Default);
        }
    }

    public class PlayerStopedCondition
    {
        private readonly IInputService _inputService;

        public PlayerStopedCondition(IInputService inputService)
        {
            _inputService = inputService;
        }

        public IObservable<Unit> Stoped()
        {
            return _inputService.MoveDirection
                .Where(dir => dir.sqrMagnitude < 0.01f)
                .Select(_ => Unit.Default);
        }
    }

    public class TargetFindCondition
    {
        private readonly ITargetFinder _targetFinder;

        public TargetFindCondition(ITargetFinder targetFinder)
        {
            _targetFinder = targetFinder;
        }

        public IObservable<Unit> Finded()
        {
            return _targetFinder.Target
                .Where(target => target != null)
                .Select(_ => Unit.Default);
        }
    }
}
