using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.View
{
    public class AnimationEvents : MonoBehaviour
    {
        [SerializeField] private HitTrigger _hitTrigger;

        private UniTaskCompletionSource _attackFinishedSource;
        public ReactiveCommand<Collider[]> Hitted { get; private set; } = new(); 

        public void OnAttack()
        {

            Collider[] hitColliders = Physics.OverlapBox(
                _hitTrigger.transform.position,
                _hitTrigger.HitBoxSize / 2,
                _hitTrigger.transform.rotation);

            Hitted.Execute(hitColliders);
        }

        public async UniTask WaitAttackFinished()
        {
            _attackFinishedSource = new UniTaskCompletionSource();
            await _attackFinishedSource.Task;
        }

        public void OnAttackFinished()
        {
            _attackFinishedSource?.TrySetResult();
        }
    }
}
