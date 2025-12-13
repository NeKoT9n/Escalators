using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using System;
using UniRx;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Obstacles.Model
{
    public class ObstacleView : MonoBehaviour, IWorldView
    {
        public GameObject GameObject => gameObject;

        private float _speed;
        private IDisposable _disposable;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<ICollidable>(out var collidable) == false)
                return;

            collidable.OnColided(this);
        }

        public void Initialize(float speed)
        {
            _speed = speed;

            _disposable = Observable.EveryUpdate().Subscribe(_ => Move());
        }

        private void Move()
        {
            transform.position += _speed * Time.deltaTime * transform.forward;
        }

        public void OnKillZoneEnter()
        {
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _disposable?.Dispose();
        }
    }


}
