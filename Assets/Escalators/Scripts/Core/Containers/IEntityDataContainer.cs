using Assets.CodeCore.Scripts.Game.Services.Entitieys.Data;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;

namespace Assets.CodeCore.Scripts.Game.Providers.Entities
{
    public interface IEntityDataContainer
    {
        public EntityData GetBy(EntityTypeId typeId);
    }

}
