using Assets.CodeCore.Scripts.Game.Services.Entitieys.Factory;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using Assets.Escalators.Scripts.Game.Services.Entities.Factory.Model.Brains.Plugins;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using System.Collections.Generic;

namespace Assets.CodeCore.Scripts.Game.Services
{
    public class BrainFactory : PluginFactoryBase<EntityTypeId, IBrainFactoryPlugin>, IBrainFactory
    {
        protected BrainFactory(IEnumerable<IBrainFactoryPlugin> plugins) 
            : base(plugins) { }

        public Brain Create(Entity model, EntityTypeId typeId)
        {
            var factory = GetFactory(typeId);

            return factory.Create(model);
        }
    }
}
