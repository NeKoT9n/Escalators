using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine;
using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine.States.Interfaces;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States.Transitions;
using UnityEngine;


namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States
{
    public class EntityMoveState : TransitionState, IUpdatableState
    {
        private readonly Entity _entity;
        private readonly IMover _mover;

        public EntityMoveState(
            Entity entity,
            IMover mover,
            IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
            _entity = entity;
            _mover = mover;
        }

        public override void Enter()
        {
            base.Enter();

            _entity.IsMoving.Value = true;
        }

        public void Update()
        {
            _mover.Move(_entity, Time.deltaTime);
        }

        public override void Exit()
        {
            base.Exit();
            _entity.IsMoving.Value = false;
        }

    }
}
