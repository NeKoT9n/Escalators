namespace Assets.Escalators.Scripts.Game.Services.Obstacles.Spawner
{

    public class ObstacleSpawner : IObstacleSpawner
    {
        private readonly ObstacleFactory _obstacleFactory;
        private readonly ObstacleSpawnMarker _spawnData;

        public ObstacleSpawner(
            ObstacleFactory obstacleFactory,
            ObstacleSpawnMarker spawnData)
        {
            _obstacleFactory = obstacleFactory;
            _spawnData = spawnData;
        }

        public async void Spawn()
        {
            await _obstacleFactory.Create(_spawnData);
        }
    }
}
