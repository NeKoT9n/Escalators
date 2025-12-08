using Assets.Escalators.Scripts.Game.Services.Obstacles.Model;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Obstacles.Spawner
{

    public class ObstacleSpawner : IObstacleSpawner
    {
        private readonly ObstacleFactory _obstacleFactory;

        public ObstacleSpawner(ObstacleFactory obstacleFactory)
        {
            _obstacleFactory = obstacleFactory;
        }

        public async UniTask<ObstacleView> Spawn(Vector3 position, Quaternion rotation)
        {
            return await _obstacleFactory.Create(position, rotation);
        }
    }
}
