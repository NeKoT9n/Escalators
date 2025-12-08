using Assets.Escalators.Scripts.Game.Services.Obstacles.Model;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Obstacles.Spawner
{
    public interface IObstacleSpawner
    {
        public UniTask<ObstacleView> Spawn(Vector3 position, Quaternion rotation);
    }
}
