using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Services.Entitieys.Data;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using Cysharp.Threading.Tasks;
using System;

namespace Assets.CodeCore.Scripts.Game.Providers.Entities
{
    public interface IEntityDataProvider
    {
        public EntityData GetBy(EntityTypeId typeId);
    }

    public class EntityDataProvider : IEntityDataProvider, IAsyncInitializable
    {
        public EntityData GetBy(EntityTypeId typeId)
        {
            throw new NotImplementedException();
        }

        public UniTask Initialize()
        {
            throw new NotImplementedException();
        }
    }

}
