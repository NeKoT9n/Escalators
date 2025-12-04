using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Abstractions
{
    public class PlayerService : IPlayerService
    {
        public IReadOnlyReactiveProperty<Player> Player => _player;

        private readonly ReactiveProperty<Player> _player;

        public void SetPlayer(Player player)
        {
            _player.Value = player;
        }
    }

}
