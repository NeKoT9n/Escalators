using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.TargetFinder;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;

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
            IMover mover = new DirectionMover();
            IAttacker attacker = new EmptyAttacker();
            ITargetFinder targetFinder = new TargetFinder(Key);

            PlayerMoveState move = new(_inputService, entity, mover);
            PlayerFindTargetState findTarget = new(targetFinder, _inputService, entity);
            EntityAttackState attack = new(targetFinder, attacker, entity);

            var brain = new PlayerBrain(move, findTarget, attack);
            brain.Initialize();

            return brain;
        }
    }
}
