using Assets.Escalators.Scripts.Game.Services.Camera;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using Assets.Escalators.Scripts.Game.Services.LoadLevel;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.CodeCore.Scripts.Game.Services
{
    public class LoadLevelService : ILoadLevelService
    {
        private readonly EntityFactory _entityFactory;
        private readonly IPlayerService _playerService;
        private readonly ILevelBuilder _levelBuilder;

        public LoadLevelService(
            EntityFactory entityFactory,
            IPlayerService playerService,
            ILevelBuilder levelBuilder)
        {
            _entityFactory = entityFactory;
            _playerService = playerService;
            _levelBuilder = levelBuilder;
        }

        public async UniTask LoadLevel(LevelData levelData)
        {
            await _levelBuilder.Build(levelData.BuildData);
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
