using Assets.CodeCore.Scripts.Game.Services.Entitieys.Data;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using UnityEngine;

namespace Assets.CodeCore.Scripts.Game.Services.Entitieys.Factory.Model
{
    public interface IEntityFactoryPlugin : IFactoryPlugin<EntityTypeId>
    {
        public Entity Create(EntityData entityData, Vector2 spawnPosition);
    }
}
