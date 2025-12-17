using Assets.Escalators.Scripts.Core.View;
using Assets.Escalators.Scripts.Game.Services.Level.Model;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Level.LevelParts.Arenas
{
    public class Arena : LevelPart
    {
        public List<Transform> EnemySpawnPositions { get; }
        public ArenaTrigger ArenaTrigger { get; }
        public Arena(
            List<Transform> enemySpawnPositions,
            ArenaTrigger arenaTrigger,
            Vector3 spawnPosition) : base(spawnPosition)
        {
            EnemySpawnPositions = enemySpawnPositions;
            ArenaTrigger = arenaTrigger;
        }

        public class PlayerEnterArenaSignal
        {

        }

    }
}
