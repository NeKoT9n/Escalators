using Assets.CodeCore.Scripts.Game.Providers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.CodeCore.Scripts.Game.Services.Entitieys.Data
{
    [CreateAssetMenu(menuName = ("Data/Entities"), fileName = ("EntityData"))]
    public class EntityData : ScriptableObjectGameData
    {

        [SerializeField] private AssetReferenceGameObject _prefab;

        public AssetReferenceGameObject Prefab => _prefab;

    }
}
