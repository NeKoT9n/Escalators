using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model
{
    public class EmptyMover : IMover
    {
        public void Move(Entity entity, float deltaTime)
        {
            return;
        }
    }
}
