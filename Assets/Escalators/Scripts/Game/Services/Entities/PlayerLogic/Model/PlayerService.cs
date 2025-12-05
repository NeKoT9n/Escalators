using Assets.Escalators.Scripts.Core.Utils.Extentions;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic;
using Cysharp.Threading.Tasks;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Abstractions
{
    public class PlayerService : IPlayerService
    {
        public IReadOnlyReactiveProperty<Player> Player => _player;
        public IReactiveCommand<SpawnCommand> SpawnPlayer => _spawnPlayer;


        private readonly ReactiveCommand<SpawnCommand> _spawnPlayer = new();

        private readonly ReactiveProperty<Player> _player = new();

        public UniTask Spawn(Player player)
        {
            _player.Value = player;

            SpawnCommand spawnCommand = new(player);

            return _spawnPlayer.ExecuteAwaitable(spawnCommand);
        }
    }
}
