using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using Assets.Escalators.Scripts.Game.Services.Level.LevelParts.Roads;
using Assets.Escalators.Scripts.Game.Services.Level.Tracks.Model;
using Assets.Escalators.Scripts.Game.Services.LoadLevel;
using Assets.Escalators.Scripts.Game.Services.Obstacles.Model;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeCore.Scripts.Game.Services
{
    public class LoadLevelService : ILoadLevelService
    {
        private readonly EntityFactory _entityFactory;
        private readonly IPlayerService _playerService;
        private readonly ILevelBuilder _levelBuilder;
        private readonly IObstacleService _obstacleService;
        private readonly RoadSpawnerFactory _roadSpawnerFactory;
        private LevelBuildedData _levelBuildedData;

        public LoadLevelService(
            EntityFactory entityFactory,
            IPlayerService playerService,
            ILevelBuilder levelBuilder,
            IObstacleService obstacleService,
            RoadSpawnerFactory roadSpawnerFactory)
        {
            _entityFactory = entityFactory;
            _playerService = playerService;
            _levelBuilder = levelBuilder;
            _obstacleService = obstacleService;
            _roadSpawnerFactory = roadSpawnerFactory;
        }

        public async UniTask LoadLevel(LevelData levelData)
        {
            _levelBuildedData = await LoadLevelView(levelData);
            
            await LoadPlayer(_levelBuildedData.StartPlace.Model.PlayerSpawnPosition);

            CreateSpawners(_levelBuildedData);            
        }

        private void CreateSpawners(LevelBuildedData levelBuildedData)
        {
            foreach (var track in levelBuildedData.Tracks)
            {
                List<RoadSpawner> spawners = new();
                foreach(var road in track.Model.Roads)
                {
                    spawners.Add(_roadSpawnerFactory.Create(road));
                }

                TrackSpawner trackSpawner = new(spawners);

                _obstacleService.AddTrackSpawner(trackSpawner);
            }
            
        }

        private async UniTask<LevelBuildedData> LoadLevelView(LevelData levelData)
        {
            return await _levelBuilder.Build(levelData.BuildData);
        }

        private async UniTask LoadPlayer(Vector2 position)
        {
            Player player = (Player)_entityFactory
                            .Create(EntityTypeId.Player, position);

            await _playerService.Spawn(player);
        }
    }
}
