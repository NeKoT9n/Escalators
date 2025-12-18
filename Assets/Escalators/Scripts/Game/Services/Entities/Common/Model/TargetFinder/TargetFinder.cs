using Assets.Escalators.Scripts.Game.Services.Entities.Common.View;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using UniRx;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.TargetFinder
{
    public class TargetFinder : ITargetFinder
    {
        public IReadOnlyReactiveProperty<EntityView> Target => _target;
        private EntityTypeId _friendlyType => _entity.Type;

        private readonly ReactiveProperty<EntityView> _target = new();
        private readonly Entity _entity;

        public TargetFinder(Entity entity)
        {
            _entity = entity;
        }

        public void FindTarget()
        {
            _target.Value = null;

            var results = Physics.OverlapSphere(
                _entity.Position.Value,
                _entity.TargetingRange);

            foreach(var collier in results)
            {
                if(collier.TryGetComponent<EntityView>(out var view))
                {
                    if (view.EntityType != _friendlyType)
                    {
                        _target.Value = view;
                        break;
                    }
                    
                }
            }

        }
    }
}
