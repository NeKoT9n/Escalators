using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine;
using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine.States.Interfaces;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States.Transitions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.TargetFinder;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.View;
using System;
using UniRx;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States
{
    public class EntityFindTargetState : TransitionState, IUpdatableState
    {
        private readonly ITargetFinder _targetFinder;
        private readonly Entity _entity;

        public EntityFindTargetState(
            IStateSwitcher stateSwitcher,
            ITargetFinder targetFinder,
            Entity entity) : base(stateSwitcher)
        {
            _targetFinder = targetFinder;
            _entity = entity;
        }

        public void Update()
        {
            _targetFinder.FindTarget(_entity.Position.Value,  _entity.AttackRange);      
        }

    }
}
