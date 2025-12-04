using Assets.Escalators.Scripts.Game.Services.Entities.EnemyLogic;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model
{
    public class EnemyService : IEnemyService
    {
        public IReadOnlyReactiveCollection<Enemy> Enemies => _enemies;
        
        private readonly ReactiveCollection<Enemy> _enemies = new();

        public void Add(Enemy entity)
        {
            _enemies.Add(entity);
        }

    }
}
