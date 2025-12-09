using Assets.Escalators.Scripts.Game.Services.Level.Tracks.Model;

namespace Assets.Escalators.Scripts.Game.Services.Obstacles.Model
{
    public interface IObstacleService
    {
        public void AddTrackSpawner(TrackSpawner spawner);
        public void StartSpawnObstacles();
    }
}
