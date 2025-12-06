using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using Assets.Escalators.Scripts.Game.Services.Obstacles.Spawner;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UniRx;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Obstacles.Model
{
    public class ObstacleService 
    {
        private readonly IEnumerable<ObstacleSpawner> _spawners;
        private CancellationTokenSource _cancellationToken;

        private readonly float _durationBetweenSpawnMin = 1f;
        private readonly float _durationBetweenSpawnMax = 3f;

        public ObstacleService(IEnumerable<ObstacleSpawner> spawners)
        {
            _spawners = spawners;
        }

        public void StartSpawn()
        {
            _cancellationToken = new();
            SpawnAsync(_cancellationToken.Token).Forget();
        }

        public void StopSpawn()
        {

        }

        public async UniTask SpawnAsync(CancellationToken cancellation)
        {
            while (cancellation.IsCancellationRequested == false)
            {
                foreach(var spawner in _spawners)
                {
                    spawner.Spawn();
                    await UniTask.WaitForSeconds(GetDurationBetweenSpawn());
                }
            }
        }

        private float GetDurationBetweenSpawn()
        {
            return Random.Range(_durationBetweenSpawnMin, _durationBetweenSpawnMax + 1);
        }
    }

    public class ObstacleView : MonoBehaviour, IWorldView
    {
        public GameObject GameObject => gameObject;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<ICollidable>(out var collidable) == false)
                return;

            collidable.OnColided(this);
        }

    }

    public interface ICollidable
    {
        public void OnColided(ObstacleView obstacleView);
    }


}
