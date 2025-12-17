using Assets.CodeCore.Scripts.Game.Services.Entitieys.Data;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using Assets.Escalators.Scripts.Game.Services.Entities.EnemyLogic;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using UnityEngine;

namespace Assets.CodeCore.Scripts.Game.Services.Entitieys.Factory.Model
{
    public class EnemyFactoryPlugin : IEntityFactoryPlugin
    {
        public EntityTypeId Key => EntityTypeId.Enemy;

        public Entity Create(EntityData entityData, Vector3 spawnPosition)
        {
            return new Enemy(spawnPosition, entityData);
        }
    }
}
