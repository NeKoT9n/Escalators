using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Core.Utils.Extentions;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.EnemyLogic;
using Assets.Escalators.Scripts.Game.Services.Entities.EnemyLogic.Model;
using Cysharp.Threading.Tasks;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model
{
    public class EnemyService : IEnemyService, IUpdatable
    {
        public IReadOnlyReactiveCollection<Enemy> Enemies => _enemies;
        public IReactiveCommand<SpawnCommand> Spawned => _spawned;

        public IReactiveCommand<Unit> DiedAll => _diedAll;

        private readonly ReactiveCommand<SpawnCommand> _spawned = new();
        private readonly ReactiveCommand<Unit> _diedAll = new();

        private readonly ReactiveCollection<Enemy> _enemies = new();
        private EnemySpawner _enemySpawner;


        public async UniTask Spawn(Enemy entity)
        {
            SpawnCommand spawnCommand = new(entity);
            _enemies.Add(entity);

            entity.Died.
                Subscribe(_ => Kill(entity));

            await _spawned.ExecuteAwaitable(spawnCommand);
        }

        public void Kill(Enemy entity)
        {
            _enemies.Remove(entity);

            if (_enemies.Count <= 0)
                _diedAll.Execute(Unit.Default);
        }

        public void SetSpawner(EnemySpawner enemySpawner)
        {
            _enemySpawner = enemySpawner;
        }

        public async UniTask Spawn()
        {
            await _enemySpawner.Spawn();
        }

        public void AppeareAll()
        {
            foreach(var enemy in _enemies)
            {
                enemy.Appeared.Execute();
            }
        }

        public void Update()
        {
            foreach(var enemy in _enemies)
            {
                enemy.UpdateBrain();
            }
        }
    }
}
