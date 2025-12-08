using Assets.Escalators.Scripts.Core.View;
using Assets.Escalators.Scripts.Game.Services.Level.Model;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Level.LevelParts.Arenas
{
    public class Arena : LevelPart
    {
        public List<Transform> EnemySpawnPositions { get; }
        public Arena(
            List<Transform> enemySpawnPositions,
            Vector3 spawnPosition) : base(spawnPosition)
        {
            EnemySpawnPositions = enemySpawnPositions;
        }

    }
}
