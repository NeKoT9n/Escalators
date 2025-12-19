

using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Box
{
    public class ChestBoxService : IChestBoxService
    {
        private readonly ChestBoxView _chestBox;
        private readonly IPlayerService _playerService;

        private Vector3 _spawnOffset = new(0, 0, 2);
        private float _positinY;

        public ChestBoxService(ChestBoxView chestBox, IPlayerService playerService)
        {
            _chestBox = chestBox;
            _playerService = playerService;

            _positinY = _chestBox.transform.position.y;
        }

        public async UniTask SpawnAsync()
        {
            var spawnPosition = _playerService.Position + _spawnOffset;
            spawnPosition.y = _positinY;

            _chestBox.transform.position = spawnPosition;

            await _chestBox.Appear();
        }
    }
}
