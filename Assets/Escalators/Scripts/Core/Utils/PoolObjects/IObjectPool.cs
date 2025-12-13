using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using Assets.Escalators.Scripts.Game.Services.Obstacles.Model;
using Assets.Escalators.Scripts.Game.Services.Obstacles.Spawner;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Escalators.Scripts.Core.Utils.PoolObjects
{
    public interface IObjectPool<TView> where TView : IWorldView
    {
        UniTask<TView> Get(Vector3 position, Quaternion rotation);
    }

    public class ObstacleObjectPool : IObjectPool<ObstacleView>
    {
        private readonly ObstacleFactory _obstacleFactory;
        private readonly List<ObstacleView> _pool = new();

        public ObstacleObjectPool(ObstacleFactory obstacleFactory)
        {
            _obstacleFactory = obstacleFactory;
        }

        public async UniTask<ObstacleView> Get(Vector3 position, Quaternion rotation)
        {
            ObstacleView view = GetFreeObject()
                ?? await CreateNew(position, rotation);

            view.gameObject.SetActive(true);

            return view;
        }

        private ObstacleView GetFreeObject()
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                if (_pool[i].gameObject.activeSelf == false)
                {
                    var obj = _pool[i];
                    return obj;
                }
            }

            return null;
        }

        private async UniTask<ObstacleView> CreateNew(Vector3 position, Quaternion rotation)
        {
            var view = await _obstacleFactory.Create(position, rotation);
            _pool.Add(view);

            return view;
        }

    }
}
