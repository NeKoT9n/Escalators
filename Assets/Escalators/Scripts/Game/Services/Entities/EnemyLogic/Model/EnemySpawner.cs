using Assets.CodeCore.Scripts.Game.Services;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using Assets.Escalators.Scripts.Game.Services.Level.LevelParts.Arenas;
using System.Collections.Generic;

namespace Assets.Escalators.Scripts.Game.Services.Entities.EnemyLogic.Model
{
    public class EnemySpawner
    {
        private readonly IEnemyService _enemyService;
        private readonly EntityFactory _entityFactory;
        private readonly Arena _arena;

        public EnemySpawner(IEnemyService enemyService, EntityFactory entityFactory, Arena arena)
        {
            _enemyService = enemyService;
            _entityFactory = entityFactory;
            _arena = arena;
        }

        public void Spawn()
        {
            foreach(var spawnPoint in _arena.EnemySpawnPositions)
            {
                var enemy = (Enemy)_entityFactory.Create(EntityTypeId.Enemy, spawnPoint.position);
                _enemyService.Add(enemy);
            }
        }
    }
}
