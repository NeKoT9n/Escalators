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
        private readonly IEntityDataContainer _entityDataProvider;
        private readonly IBrainFactory _brainFactory;

        public EntityFactory(
            IEntityDataContainer entityDataProvider,
            IBrainFactory brainFactory,
            IEnumerable<IEntityFactoryPlugin> factories) : base (factories)
        {
            _entityDataProvider = entityDataProvider;
            _brainFactory = brainFactory;
        }

        public Entity Create(EntityTypeId typeId, Vector2 position)
        {
            EntityData data = _entityDataProvider.GetBy(typeId);

            var factory = GetFactory(typeId);

            var entity = factory.Create(data, position);

            Brain brain = _brainFactory.Create(entity, entity.Type);

            entity.SetBrain(brain);

            return entity;
        }

    }
}
