using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.EnemyLogic;
using Assets.Escalators.Scripts.Game.Services.Entities.EnemyLogic.Model;
using Cysharp.Threading.Tasks;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model
{
    public interface IEnemyService
    {
        public IReadOnlyReactiveCollection<Enemy> Enemies { get; }
        public IReactiveCommand<SpawnCommand> Spawned { get; }
        public IReactiveCommand<Unit> DiedAll { get; }
        public void Kill(Enemy enemy);
        public UniTask Spawn(Enemy entity);
        public void SetSpawner(EnemySpawner enemySpawner);
        public UniTask Spawn();
        public void AppeareAll();
    }
}
