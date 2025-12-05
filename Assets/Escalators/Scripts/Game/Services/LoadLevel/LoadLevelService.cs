using Assets.Escalators.Scripts.Game.Services.Camera;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeCore.Scripts.Game.Services
{
    public class LoadLevelService : ILoadLevelService
    {
        private readonly EntityFactory _entityFactory;
        private readonly IPlayerService _playerService;
        private readonly ICameraService _cameraService;

        public LoadLevelService(
            EntityFactory entityFactory,
            IPlayerService playerService,
            ICameraService cameraService)
        {
            _entityFactory = entityFactory;
            _playerService = playerService;
            _cameraService = cameraService;
        }

        public async UniTask LoadLevel(LevelData levelData)
        {
            await LoadPlayer(levelData.PlayerSpawnPoint.Position);
        }

        private async UniTask LoadPlayer(Vector2 position)
        {
            Player player = (Player)_entityFactory
                            .Create(EntityTypeId.Player, position);

            await _playerService.Spawn(player);
        }
    }



}
