using Assets.Escalators.Scripts.Core.Utils.PoolObjects;
using Assets.Escalators.Scripts.Game.Services.Obstacles.Model;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Obstacles.Spawner
{

    public class ObstacleSpawner : IObstacleSpawner
    {
        private readonly IObjectPool<ObstacleView> _obstaclePool;

        public ObstacleSpawner(IObjectPool<ObstacleView> obstaclePool)
        {
            _obstaclePool = obstaclePool;
        }

        public async UniTask<ObstacleView> Spawn(Vector3 position, Quaternion rotation)
        {
            return await _obstaclePool.Get(position, rotation);
        }
    }
}
