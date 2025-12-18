using Assets.Escalators.Scripts.Game.Services.Entities.Common.View;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using Assets.Escalators.Scripts.Game.Services.Obstacles.Model;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.View
{
    public class PlayerView : EntityView, ICollidable
    {
        public override EntityTypeId EntityType => EntityTypeId.Player;
        public IReactiveCommand<ObstacleView> Collided => _collided;

        private readonly ReactiveCommand<ObstacleView> _collided = new();

        public void OnColided(ObstacleView obstacle)
        {
            _collided.Execute(obstacle);
        }
    }
}
