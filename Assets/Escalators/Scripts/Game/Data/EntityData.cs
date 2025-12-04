using Assets.CodeCore.Scripts.Game.Providers;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.CodeCore.Scripts.Game.Services.Entitieys.Data
{
    [CreateAssetMenu(menuName = ("Data/Entities"), fileName = ("EntityData"))]
    public class EntityData : ScriptableObjectGameData
    {
        [SerializeField] private EntityTypeId _entityType;
        [SerializeField] private AssetReferenceGameObject _prefab;
        [SerializeField] private float _hp = 100f;
        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] private float _attackRange = 1f;

        public AssetReferenceGameObject Prefab => _prefab;
        public float HP => _hp;
        public float MoveSpeed => _moveSpeed;
        public float AttackRange => _attackRange;
        public EntityTypeId Type => _entityType;

    }
}
