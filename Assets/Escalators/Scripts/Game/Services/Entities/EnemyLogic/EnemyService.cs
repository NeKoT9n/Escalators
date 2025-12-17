using Assets.Escalators.Scripts.Game.Services.Entities.EnemyLogic;
using Assets.Escalators.Scripts.Game.Services.Entities.EnemyLogic.Model;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model
{
    public class EnemyService : IEnemyService
    {
        public IReadOnlyReactiveCollection<Enemy> Enemies => _enemies;
        
        private readonly ReactiveCollection<Enemy> _enemies = new();
        private EnemySpawner _enemySpawner;

        public void Add(Enemy entity)
        {
            _enemies.Add(entity);
        }

        public void SetSpawner(EnemySpawner enemySpawner)
        {
            _enemySpawner = enemySpawner;
        }

        public void Spawn()
        {
            _enemySpawner.Spawn();
        }
    }
}
