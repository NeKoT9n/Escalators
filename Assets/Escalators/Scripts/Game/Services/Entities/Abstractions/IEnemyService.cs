using Assets.Escalators.Scripts.Game.Services.Entities.EnemyLogic;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model
{
    public interface IEnemyService
    {
        public IReadOnlyReactiveCollection<Enemy> Enemies { get; }
        public void Add(Enemy entity);
    }
}
