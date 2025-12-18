using Assets.Escalators.Scripts.Game.Services.Entities.Common.View;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.TargetFinder
{
    public interface ITargetFinder
    {
        public IReadOnlyReactiveProperty<EntityView> Target { get; }
        public void FindTarget();
    }
}
