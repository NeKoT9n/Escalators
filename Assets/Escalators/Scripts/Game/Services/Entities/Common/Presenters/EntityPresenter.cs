using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.View;
using Cysharp.Threading.Tasks;
using System;
using UniRx;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Presenters
{
    public class EntityPresenter : IInitializable, IDisposable
    {
        private readonly Entity _entity;
        private readonly EntityView _entityView;

        private readonly CompositeDisposable _disposables = new();
        public EntityPresenter(Entity entity, EntityView entityView)
        {
            _entity = entity;
            _entityView = entityView;
        }

        public virtual void Initialize()
        {
            _entity.Position
                .Subscribe(position => _entityView.Move(position))
                .AddTo(_disposables);

            _entity.Rotation
                .Subscribe(rotation => _entityView.SetRotation(rotation))
                .AddTo(_disposables);

            _entity.Appeared
                .Subscribe(_ => _entityView.PlayAppereEffect())
                .AddTo(_disposables);

            _entity.IsMoving
                .Subscribe(isMoving => _entityView.PlayRunAnimation(isMoving))
                .AddTo(_disposables);

            _entity.Attacked
                .Subscribe(async command => 
                    {
                        await _entityView.PlayAttackAnimation();
                        command.Completion.TrySetResult();
                    })
                .AddTo(_disposables);

            _entity.Died
                .Subscribe(_ => _entityView.Kill())
                .AddTo(_disposables);

            _entityView.AttackHit
                .Subscribe(hits => HandleHits(hits))
                .AddTo(_disposables);

            _entityView.Damageted
                .Subscribe(damage => _entity.ApplyDamage(damage))
                .AddTo(_disposables);

        }

        private void HandleHits(Collider[] hits)
        {
            foreach(var hit in hits)
            {
                if (hit.TryGetComponent<IDamagetable>(out var target))
                {      
                    _entity.DealDamage(target);
                }
            }
        }

        public virtual void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
