using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Abstractions
{
    public class SpawnCommand : UniTaskCommand
    {
        public Entity Entity;

        public SpawnCommand(Entity entity) : base()
        {
            Entity = entity;
        }
    }
}
