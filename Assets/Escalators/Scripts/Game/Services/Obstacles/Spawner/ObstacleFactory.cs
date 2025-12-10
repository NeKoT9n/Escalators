using Assets.CodeCore.Scripts.Game.Services;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using Assets.Escalators.Scripts.Game.Services.Obstacles.Model;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Obstacles.Spawner
{
    public class ObstacleFactory 
    {
        private readonly IGameDataProvider<ObstacleData> _obstacleDataProvider;
        private readonly WorldFactory _worldFactory;

        public ObstacleFactory(
            IGameDataProvider<ObstacleData> obstacleDataProvider,
            WorldFactory worldFactory)
        {
            _obstacleDataProvider = obstacleDataProvider;
            _worldFactory = worldFactory;
        }

        public async UniTask<ObstacleView> Create(Vector3 position, Quaternion rotation)
        {
            var prefab = _obstacleDataProvider.Data.Prefab;

            return await _worldFactory
                .Create<ObstacleView>(prefab, position, rotation);

        }
    }
}
