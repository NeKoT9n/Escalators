using Assets.CodeCore.Scripts.Game.Services.Entitieys.Factory;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.View;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

namespace Assets.CodeCore.Scripts.Game.Services.Entitieys.Model
{
    public class EntityViewFactory : PluginFactoryBase<EntityTypeId, IEntityViewFactoryPlugin>
    {
        public EntityViewFactory(
            IEnumerable<IEntityViewFactoryPlugin> factories) : base(factories) { }

        public async UniTask<Escalators.Scripts.Game.Services.Entities.Common.View.EntityView> Spawn(Escalators.Scripts.Game.Services.Entities.Common.Entity entity)
        {
            var factory = GetFactory(entity.Type);
            return await factory.Create(entity.Prefab, entity.Position.Value);
        }

    }
}
