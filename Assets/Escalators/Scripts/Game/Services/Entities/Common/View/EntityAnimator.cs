using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.View
{
    public class EntityAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Vector3 _startSpawnScale = new(0.2f, 0.2f, 0.2f);
        [SerializeField] private float _spawnDuration = 0.5f;
        [SerializeField] private Ease _spawnEase = Ease.InOutElastic;
        [SerializeField] private AnimationEvents _events;
        public IReactiveCommand<Collider[]> Hitted => _events.Hitted;

        private const string ATTACK_TRIGGER = "attack";
        private const string IS_RUNNING = "isRunning";


        private Vector3 _defualtScale;

        private void Awake()
        {
            _defualtScale = transform.localScale;
        }

        public void PlayRunAnimation(bool isRunning)
        {
            _animator.SetBool(IS_RUNNING, isRunning);
        }

        public async UniTask PlayAttackAnimation()
        {
            _animator.SetTrigger(ATTACK_TRIGGER);
            await _events.WaitAttackFinished();
        }

        public virtual void PlayAppereEffect()
        {
            transform.localScale = _startSpawnScale;
            gameObject.SetActive(true);

            transform.DOScale(_defualtScale, _spawnDuration).SetEase(_spawnEase);
        }
    }
}
