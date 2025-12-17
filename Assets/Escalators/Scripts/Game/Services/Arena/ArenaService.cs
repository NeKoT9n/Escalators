using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model;
using Assets.Escalators.Scripts.Game.Services.Level.LevelParts.Arenas;
using System;
using Zenject;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services
{
    public class ArenaService : IDisposable, IArenaService
    {
        private Arena _arena;
        private readonly IEnemyService _enemyService;
        private readonly SignalBus _eventBus;

        private IDisposable _disposable;

        public ArenaService(IEnemyService enemyService, SignalBus eventBus)
        {
            _enemyService = enemyService;
            _eventBus = eventBus;
        }

        public void SetArena(Arena arena)
        {
            _arena = arena;

            _disposable =
                _arena.ArenaTrigger.Triggered
                .Subscribe(_ => _eventBus.Fire(new PlayerEnterArenaSignal()));
        }

        public async void StartBattle()
        {
            await _enemyService.Spawn();
            _enemyService.AppeareAll();
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
