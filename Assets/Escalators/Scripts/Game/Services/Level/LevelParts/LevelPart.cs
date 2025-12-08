using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Level.Model
{
    public class LevelPart
    {
        public Vector3 Position { get; set; }

        public LevelPart(Vector3 spawnPosition)
        {
            Position = spawnPosition;
        }
    }
}
