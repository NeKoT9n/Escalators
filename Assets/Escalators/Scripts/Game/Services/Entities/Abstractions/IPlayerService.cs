using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Abstractions
{
    public interface IPlayerService
    {
        public IReadOnlyReactiveProperty<Player> Player { get; }
        public Vector3 Position { get; }
        public IReactiveCommand<SpawnCommand> SpawnPlayer { get; }
        public IReactiveCommand<Unit> Died { get; }
        public UniTask Spawn(Player player);
        public void Appear();
        public void Kill();
    }

}
