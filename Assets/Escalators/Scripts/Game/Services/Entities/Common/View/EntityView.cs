using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using DG.Tweening;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.View
{
    public class EntityView : MonoBehaviour, IWorldView
    {
        [SerializeField] private Vector3 _startSpawnScale = new(0.2f, 0.2f, 0.2f);
        [SerializeField] private float _spawnAnimationDuration = 0.5f;
        [SerializeField] private Ease _spawnEase = Ease.InOutElastic;

        public GameObject GameObject => gameObject;

        private Vector3 _defualtScale;

        private void Awake()
        {
            _defualtScale = transform.localScale;   
        }

        public void Move(Vector3 position)
            => transform.position = new(position.x, transform.position.y, position.z);

        public void SetRotation(Quaternion rotation)
            => transform.rotation = rotation;

        public void PlayAppereEffect()
        {
            transform.localScale = _startSpawnScale;
            gameObject.SetActive(true);

            transform.DOScale(_defualtScale, _spawnAnimationDuration).SetEase(_spawnEase);
        }
    }
}
