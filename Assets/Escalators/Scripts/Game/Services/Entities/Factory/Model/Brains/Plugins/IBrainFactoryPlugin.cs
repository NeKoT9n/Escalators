using Assets.CodeCore.Scripts.Game.Services.Entitieys.Factory;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Factory.Model.Brains.Plugins
{
    public interface IBrainFactoryPlugin : IFactoryPlugin<EntityTypeId>
    {
        public Brain Create(Entity entity);
    }
}
