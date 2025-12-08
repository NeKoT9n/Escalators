using Assets.CodeCore.Scripts.Game.Providers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Escalators.Scripts.Game.Services.Obstacles.Spawner
{
    [CreateAssetMenu(menuName = ("Data/ObstacleData"), fileName = ("ObstacleData"))]
    public class ObstacleData : ScriptableObjectGameData
    {
        [SerializeField] private AssetReferenceGameObject _prefab;

        public AssetReferenceGameObject Prefab => _prefab;
    }
}
