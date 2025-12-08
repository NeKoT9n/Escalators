using Assets.Escalators.Scripts.Game.Services.Level.LevelParts.Roads;
using Assets.Escalators.Scripts.Game.Services.LoadLevel.Data;
using Assets.Escalators.Scripts.Game.Services.Obstacles.Model;
using Assets.Escalators.Scripts.Game.Services.Obstacles.Spawner;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace Assets.CodeCore.Scripts.Game.Services
{
    public class RoadSpawner
    {
        private readonly Road _model;
        private readonly IObstacleSpawner _spawner;

        public RoadSpawner(IObstacleSpawner obstacleSpawner, Road road)
        {
            _spawner = obstacleSpawner;
            _model = road;
        }

        public void StartSpawn(CancellationToken cancellationToken)
        {
            Start(cancellationToken).Forget();
        }

        public async UniTask Start(CancellationToken cancellationToken)
        {
            while (cancellationToken.IsCancellationRequested == false)
            {
                await Create(_model.LeftSpawner.position, _model.LeftSpawner.localRotation);
                await Create(_model.RightSpawner.position, _model.RightSpawner.localRotation);

                await UniTask.WaitForSeconds(
                    _model.RoadData.SpawnInterval,
                    cancellationToken: cancellationToken);
            }
        }

        private async UniTask<ObstacleView> Create(Vector3 position, Quaternion rotation)
        {
            var obstacle = await _spawner.Spawn(position, rotation);
            obstacle.Initialize(GetRandomSpeedFromData(_model.RoadData));

            return obstacle;
        }

        private float GetRandomSpeedFromData(RoadData roadData)
        {
            return Random.Range(roadData.MoveSpeedMin, roadData.MoveSpeedMax + 1);
        }

    }
}
