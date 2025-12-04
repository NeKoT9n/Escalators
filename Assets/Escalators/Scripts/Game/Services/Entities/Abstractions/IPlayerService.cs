using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Abstractions
{
    public interface IPlayerService
    {
        public IReadOnlyReactiveProperty<Player> Player { get; }
        public void SetPlayer(Player player);
    }

}
