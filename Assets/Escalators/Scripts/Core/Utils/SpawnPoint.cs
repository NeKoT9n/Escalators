using System;
using UnityEngine;

namespace Assets.CodeCore.Scripts.Game.Helpers
{
    [Serializable]
    public class SpawnPoint
    {
        [SerializeField] private Vector3 _position;

        public Vector2 Position => _position;
        public SpawnPoint(Vector2 position)
        {
            _position = position;
        }
    }
}
