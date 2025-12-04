using Assets.CodeCore.Scripts.Game.Services.Entitieys.Data;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using UnityEngine;

namespace Assets.CodeCore.Scripts.Game.Services.Entitieys.Factory.Model
{
    public class PlayerFactoryPlugin : IEntityFactoryPlugin
    {
        public EntityTypeId Key => EntityTypeId.Player;

        public Entity Create(EntityData entityData, Vector2 spawnPosition, Brain brain)
        {
            return new Player(spawnPosition, entityData, brain);
        }
    }
}
