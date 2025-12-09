using Assets.Escalators.Scripts.Game.Services.Entities.Common.View;
using Assets.Escalators.Scripts.Game.Services.Obstacles.Model;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.View
{
    public class PlayerView : EntityView, ICollidable
    {
        private ReactiveCommand<ObstacleView> _collided = new();

        public IReactiveCommand<ObstacleView> Collided => _collided;

        public void TakeDamage(float damage)
        {
            
        }

        public void OnColided(ObstacleView obstacle)
        {
            _collided.Execute(obstacle);
        }
    }
}
