using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model
{
    public class EmptyMover : IMover
    {
        public void Move(Entity entity, Vector2 input, float deltaTime)
        {
            return;
        }
    }
}
