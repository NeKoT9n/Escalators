
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Abstractions
{
    public interface IMover
    {
        public void Move();
        public void Stop();
        public void LookAt(Vector3 at);
    }
}
