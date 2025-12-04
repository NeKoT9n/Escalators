using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Abstractions
{
    public interface IMover
    {
        public void Move(Vector2 input, float deltaTime);
    }
}
