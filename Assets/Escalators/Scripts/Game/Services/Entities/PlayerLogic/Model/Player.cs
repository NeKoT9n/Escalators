using Assets.CodeCore.Scripts.Game.Services.Entitieys.Data;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic
{
    public class Player : Entity
    {
        public Player(Vector3 startPosition, EntityData entityData, Brain brain) 
            : base(startPosition, entityData, brain)
        {
        }
    }
}
