using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;

namespace Assets.CodeCore.Scripts.Game.Services
{
    public interface IBrainFactory
    {
        public Brain Create(Entity model, EntityTypeId typeId);
    }
}
