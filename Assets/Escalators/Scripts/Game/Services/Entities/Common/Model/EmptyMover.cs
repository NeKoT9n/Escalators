using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model
{
    public class EmptyMover : IMover
    {
        public void LookAt(Vector3 _)
        {
            return;
        }

        public void Move()
        {
            return;
        }

        public void Stop() 
        { 
            return;
        }
    }
}
