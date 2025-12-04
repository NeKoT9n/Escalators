using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using Cysharp.Threading.Tasks;

namespace Assets.CodeCore.Scripts.Game.Services
{
    public class LoadLevelService : ILoadLevelService
    {
        private readonly EntityFactory _entityFactory;
        private readonly PlayerService _playerService;

        public LoadLevelService(EntityFactory entityFactory, PlayerService playerService)
        {
            _entityFactory = entityFactory;
            _playerService = playerService;
        }

        public UniTask LoadLevel(LevelData levelData)
        {

            Player player = (Player)_entityFactory
                .Create(EntityTypeId.Player, levelData.PlayerSpawnPoint.Position);

            _playerService.SetPlayer(player);

            return UniTask.CompletedTask;   
        }
    }



}
