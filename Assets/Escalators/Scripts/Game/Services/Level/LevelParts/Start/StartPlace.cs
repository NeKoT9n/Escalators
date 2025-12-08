using Assets.Escalators.Scripts.Game.Services.Level.Model;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Level.Start
{
    public class StartPlace : LevelPart
    {
        public Vector3 PlayerSpawnPosition { get; }

        public StartPlace(
            Vector3 playerSpawnPosition,
            Vector3 spawnPosition) : base(spawnPosition)
        {
            PlayerSpawnPosition = playerSpawnPosition;
        }

    }
}
