using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine;
using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine.States.Interfaces;
using Assets.CodeCore.Scripts.Game.Startup.GameStates;
using System;
using System.Collections.Generic;
using UniRx;


namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States.Transitions
{
    public abstract class TransitionState : IEnterableState, IExitableState
    {
        private readonly IStateSwitcher _stateSwitcher;

        private readonly List<StateTransition> _transitions = new();

        private readonly CompositeDisposable _disposables = new();
        public TransitionState(IStateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
        }

        public void AddTransition(StateTransition transition)
        {
            _transitions.Add(transition);
        }

        public virtual void Enter()
        {
            foreach (var transition in _transitions)
            {
                transition.Condition
                    .Subscribe(_ => _stateSwitcher.TrySwitchState(transition.TargetState))
                    .AddTo(_disposables);
            }
        }

        public virtual void Exit()
        {
            _disposables.Clear();
        }

    }
}
