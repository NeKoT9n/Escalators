using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;

namespace Assets.CodeCore.Scripts.Game.Services
{
    public class BrainFactory : IBrainFactory
    {
        private readonly IInputService _inputService;

        public BrainFactory(IInputService inputService)
        {
            _inputService = inputService;
        }

        public Brain Create(Entity model, EntityTypeId typeId)
        {
            return typeId switch
            {
                EntityTypeId.Player => CreatePlayerBrain(model),
                EntityTypeId.Enemy => CreateEnemyBrain(model),
                _ => new EmptyBrain()
            };
        }

        private PlayerBrain CreatePlayerBrain(Entity model)
        {
            IMover mover = new PlayerMover(model);
            return new(_inputService, mover);
        }

        private Brain CreateEnemyBrain(Entity model)
        {
            return CreatePlayerBrain(model); // заглушка
        }
    }
}
