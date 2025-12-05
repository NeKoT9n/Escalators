using Assets.CodeCore.Scripts.Game.Services.Entitieys.Data;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.EnemyLogic
{
    public class Enemy : Entity
    {
        public Enemy(Vector3 startPosition, EntityData entityData) 
            : base(startPosition, entityData)
        {
        }
    }
}
