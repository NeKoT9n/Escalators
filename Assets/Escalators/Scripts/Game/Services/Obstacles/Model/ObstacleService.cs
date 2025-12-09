using Assets.Escalators.Scripts.Game.Services.Level.Tracks.Model;
using System.Collections.Generic;

namespace Assets.Escalators.Scripts.Game.Services.Obstacles.Model
{
    public class ObstacleService : IObstacleService
    {
        private readonly List<TrackSpawner> _spawners = new();
        public void AddTrackSpawner(TrackSpawner spawners)
        {
            _spawners.Add(spawners);
        }

        public void StartSpawnObstacles()
        {
            foreach(var trackSpawner in _spawners)
            {
                trackSpawner.StartSpawn();
            }
        }
    }
}
