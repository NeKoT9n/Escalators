using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.View;
using Cysharp.Threading.Tasks;
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
                .Subscribe(position => _entityView.Move(position))
                .AddTo(_disposables);

            _entity.Rotation
                .Subscribe(rotation => _entityView.SetRotation(rotation))
                .AddTo(_disposables);

            _entity.Appeared
                .Subscribe(_ => _entityView.PlayAppereEffect())
                .AddTo(_disposables);
            
        }

        public virtual void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
