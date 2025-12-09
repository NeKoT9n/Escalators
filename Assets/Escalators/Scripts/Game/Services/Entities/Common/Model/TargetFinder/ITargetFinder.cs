using Assets.Escalators.Scripts.Game.Services.Entities.Common.View;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using UniRx;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.TargetFinder
{
    public interface ITargetFinder
    {
        public IReadOnlyReactiveProperty<EntityView> Target { get; }
        public void FindTarget(Vector3 position, float range);
    }

    public class TargetFinder : ITargetFinder
    {
        public IReadOnlyReactiveProperty<EntityView> Target => _target; 
        private readonly EntityTypeId _friendlyType;

        readonly Collider[] _results = new Collider[10];
        private readonly ReactiveProperty<EntityView> _target = new();

        public TargetFinder(EntityTypeId enemyType)
        {
            _friendlyType = enemyType;
        }


        public void FindTarget(Vector3 position, float range)
        {

            var count = Physics.OverlapSphereNonAlloc(position, range, _results);

            if (count == 0)
                return;

            foreach(var collier in _results)
            {
                if (collier == null)
                    continue;

                if(collier.TryGetComponent<EntityView>(out var view))
                {
                    if (view.EntityTypeId != _friendlyType)
                        _target.Value = view;
                }
            }

        }
    }
}
