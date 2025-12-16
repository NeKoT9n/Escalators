using Assets.CodeCore.Scripts.Game.Startup.GameStates;
using System;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States.Transitions
{
    public class StateTransition
    {
        public IState TargetState { get; }
        public IObservable<Unit> Condition { get; }

        public StateTransition(IState targetState, IObservable<Unit> condition)
        {
            TargetState = targetState;
            Condition = condition;
        }
    }
}