using Assets.CodeCore.Scripts.Game.Providers.Entities;
using Assets.CodeCore.Scripts.Game.Services.Entitieys.Data;
using Assets.CodeCore.Scripts.Game.Services.Entitieys.Factory;
using Assets.CodeCore.Scripts.Game.Services.Entitieys.Factory.Model;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeCore.Scripts.Game.Services
{
    public class EntityFactory : PluginFactoryBase<EntityTypeId, IEntityFactoryPlugin>
    {
        private readonly IEntityDataProvider _entityDataProvider;
        private readonly IBrainFactory _brainFactory;

        public EntityFactory(
            IEntityDataProvider entityDataProvider,
            IBrainFactory brainFactory,
            IEnumerable<IEntityFactoryPlugin> factories) : base (factories)
        {
            _entityDataProvider = entityDataProvider;
            _brainFactory = brainFactory;
        }

        public Entity Create(EntityTypeId typeId, Vector2 position)
        {
            EntityData data = _entityDataProvider.GetBy(typeId);
            Brain brain = _brainFactory.Create(typeId);

            var factory = GetFactory(typeId);

            return factory.Create(data, position, brain);
        }

    }

    public interface IBrainFactory
    {
        public Brain Create(EntityTypeId typeId);
    }
}
