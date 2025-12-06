using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic;
using Cysharp.Threading.Tasks;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Abstractions
{
    public interface IPlayerService
    {
        public IReadOnlyReactiveProperty<Player> Player { get; }
        public IReactiveCommand<SpawnCommand> SpawnPlayer { get; }
        public UniTask Spawn(Player player);
        public void Appear();
        public void Kill();
    }

}
