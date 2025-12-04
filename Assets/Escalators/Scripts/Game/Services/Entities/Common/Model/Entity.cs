using Assets.CodeCore.Scripts.Game.Services.Entitieys.Data;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common
{
    public class Entity
    {
        public ReactiveProperty<Vector3> Position { get; } = new();
        public ReactiveProperty<Quaternion> Rotation { get; } = new();
        public ReactiveProperty<float> CurrentHealth { get; } = new();
        public ReactiveProperty<bool> IsDead { get; } = new(false);
        public ReactiveCommand OnAttack { get; } = new();
        public ReactiveProperty<bool> IsMoving { get; } = new(false);

        public ReactiveProperty<Brain> Brain = new();

        public EntityTypeId Type => _data.Type;
        public float MaxHp => _data.HP;
        public float MoveSpeed => _data.MoveSpeed;
        public float AttackRange => _data.AttackRange;
        public AssetReferenceGameObject Prefab => _data.Prefab;

        private readonly EntityData _data;

        public Entity(Vector3 startPosition, EntityData entityData, Brain brain)
        {
            _data = entityData;
            Position.Value = startPosition;
            CurrentHealth.Value = MaxHp;
            Brain.Value = brain;
        }

        public void ApplyDamage(float damage)
        {
            CurrentHealth.Value = Mathf.Max(0, CurrentHealth.Value - damage);
            if (CurrentHealth.Value <= 0) IsDead.Value = true;
        }

    }
}
