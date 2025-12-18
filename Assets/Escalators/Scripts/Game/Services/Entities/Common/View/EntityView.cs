using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.View
{
    [RequireComponent(typeof(EntityAnimator))]
    public abstract class EntityView : MonoBehaviour, IWorldView, IDamagetable
    {
        public abstract EntityTypeId EntityType { get; }
        public ReactiveCommand<int> Damageted { get; private set; } = new();
        public IReactiveCommand<Collider[]> AttackHit => _animator.Hitted;
        public GameObject GameObject => gameObject;

        private EntityAnimator _animator;

        private void Awake()
        {
            _animator = GetComponent<EntityAnimator>();
        }

        public void Move(Vector3 position)
            => transform.position = new(position.x, transform.position.y, position.z);

        public void SetRotation(Quaternion rotation)
            => transform.rotation = rotation;

        public void PlayAppereEffect()
        {
            _animator.PlayAppereEffect();
        }

        public void PlayRunAnimation(bool IsRunning)
        {
            _animator.PlayRunAnimation(IsRunning);
        }

        public async UniTask PlayAttackAnimation()
        {
            await _animator.PlayAttackAnimation();
        }

        public virtual void Kill()
        {
            gameObject.SetActive(false);
        }

        public void TakeDamage(int damage)
        {
            Damageted.Execute(damage);
        }
    }
}
