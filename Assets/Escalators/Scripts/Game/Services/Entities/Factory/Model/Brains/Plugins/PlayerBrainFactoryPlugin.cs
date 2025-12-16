using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine;
using Assets.CodeCore.Scripts.Game.Startup.GameStates;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States.Transitions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.TargetFinder;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using System.Collections.Generic;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Factory.Model.Brains.Plugins
{
    public class PlayerBrainFactoryPlugin : IBrainFactoryPlugin
    {
        private readonly IInputService _inputService;
        private ITargetFinder _targetFinder;

        public EntityTypeId Key => EntityTypeId.Player;

        public PlayerBrainFactoryPlugin(IInputService inputService)
        {
            _inputService = inputService;
        }

        public Brain Create(Entity entity)
        {
            PlayerStateMachine playerStateMachine = new();

            EntityMoveState move = CreateMoveState(entity, playerStateMachine);
            EntityFindTargetState findTarget = CreateFindState(entity, playerStateMachine);
            EntityAttackState attack = CreateAttackState(entity, playerStateMachine);

            PlayerMovedCondition playerMovedCondition = new(_inputService);
            PlayerStopedCondition playerStopedCondition = new(_inputService);
            TargetFindCondition targetFindCondition = new(_targetFinder);

            move.AddTransition(new StateTransition(findTarget, playerStopedCondition.Stoped()));

            findTarget.AddTransition(new StateTransition(attack, targetFindCondition.Finded()));
            findTarget.AddTransition(new StateTransition(move, playerMovedCondition.IsMoving()));

            playerStateMachine.Initialize(new List<IState>()
            { 
                move,
                findTarget,
                attack  
            });

            var brain = new PlayerBrain(playerStateMachine);
            brain.Initialize();

            return brain;
        }

        private EntityMoveState CreateMoveState(Entity entity, IStateSwitcher stateSwitcher)
        {
            IMover mover = new InputMover(_inputService);

            return new(entity, mover, stateSwitcher);
        }

        private EntityFindTargetState CreateFindState(Entity entity, IStateSwitcher stateSwitcher)
        {
            _targetFinder = new TargetFinder(friendlyType: Key);

            return new(stateSwitcher, _targetFinder, entity);      
        }
             
        private EntityAttackState CreateAttackState(Entity entity, IStateSwitcher stateSwitcher)
        {
            IAttacker attacker = new EmptyAttacker();

            return new(_targetFinder, attacker, entity);
        }
    }
}
