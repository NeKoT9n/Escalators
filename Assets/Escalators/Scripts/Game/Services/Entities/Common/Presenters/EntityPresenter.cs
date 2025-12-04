using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.View;
using System;
using UniRx;

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
                .Subscribe(position => _entityView.SetPosition(position))
                .AddTo(_disposables);

            _entity.Rotation
                .Subscribe(rotation => _entityView.SetRotation(rotation))
                .AddTo(_disposables);

            Observable
                .EveryUpdate()
                .Subscribe(_ => _entity.Brain.Value.Update())
                .AddTo(_disposables);
        }

        public virtual void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
