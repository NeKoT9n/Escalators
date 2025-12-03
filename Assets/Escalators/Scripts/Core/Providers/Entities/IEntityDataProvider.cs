using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Services.Entitieys.Data;
using Cysharp.Threading.Tasks;
using System;

namespace Assets.CodeCore.Scripts.Game.Providers.Entities
{
    public interface IEntityDataProvider
    {
        public EntityData Data { get; }
    }

    public class EntityDataProvider : IEntityDataProvider, IAsyncInitializable
    {
        public EntityData Data => throw new NotImplementedException();

        public UniTask Initialize()
        {
            throw new NotImplementedException();
        }
    }

}
