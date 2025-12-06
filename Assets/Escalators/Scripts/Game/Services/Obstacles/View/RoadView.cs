using Assets.Escalators.Scripts.Game.Services.Obstacles.Spawner;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Obstacles.View
{
    public class RoadView : MonoBehaviour
    {
        [SerializeField] private List<ObstacleSpawnMarker> _obstacleSpawners;

        public IReadOnlyCollection<ObstacleSpawnMarker> ObstacleSpawners => _obstacleSpawners;
    }
}
