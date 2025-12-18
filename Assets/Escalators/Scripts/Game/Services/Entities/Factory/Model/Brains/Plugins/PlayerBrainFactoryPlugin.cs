using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Startup.GameStates;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.TargetFinder;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Model;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using System.Collections.Generic;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Factory.Model.Brains.Plugins
{
    public class PlayerBrainFactoryPlugin : IBrainFactoryPlugin
    {
        private readonly IInputService _inputService;
        
        public EntityTypeId Key => EntityTypeId.Player;

        public PlayerBrainFactoryPlugin(IInputService inputService)
        {
            _inputService = inputService;
        }

        public Brain Create(Entity entity)
        {
            var targetFinder = new TargetFinder(entity);
            IMover mover = new InputMover(entity, _inputService);
            IAttacker attacker = new SimpleCooldownAttacker(entity);

            PlayerStateMachine playerStateMachine = new();

            PlayerMoveState move = new(mover,_inputService, playerStateMachine);
            PlayerFindTargetState findTarget = new(_inputService, targetFinder, playerStateMachine);
            PlayerAttackState playerAttack = new(attacker, mover, playerStateMachine, targetFinder);

            playerStateMachine.Initialize(new List<IState>()
            { 
                findTarget,
                move,
                playerAttack
            });

            return new PlayerBrain(playerStateMachine);
        }  
    }
}

