using Assets.Escalators.Scripts.Game.Services.Level.Model;
using Assets.Escalators.Scripts.Game.Services.LoadLevel.Data;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Level.LevelParts.Roads
{
    public class Road : LevelPart
    {
        public Transform LeftSpawner;
        public Transform RightSpawner;
        public RoadData RoadData { get; }
        public Road(
            RoadData roadData,
            Transform leftSpawnerPosition,
            Transform rightSpawnerPosition,
            Vector3 spawnPosition) : base(spawnPosition)
        {
            RoadData = roadData;
            LeftSpawner = leftSpawnerPosition;
            RightSpawner = rightSpawnerPosition;
        }

    }
}
