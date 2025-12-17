using IInitializable = Assets.CodeCore.Scripts.Game.Infostracture.IInitializable;
using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine;
using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine.States;
using Assets.CodeCore.Scripts.Game.View;
using System;
using UniRx;
using Zenject;
using Assets.Escalators.Scripts.Game.Services.Level.LevelParts.Arenas;
using Assets.CodeCore.Scripts.Game.Startup.GameStates.States;

namespace Assets.CodeCore.Scripts.Game.Services.Game
{
    public class GameService : IInitializable, IDisposable
    {
        private readonly WinCondition _winCondition;
        private readonly LoseCondition _loseCondition;
        private readonly SignalBus _eventBus;
        private readonly IStateSwitcher _stateSwitcher;

        private readonly CompositeDisposable _disposables = new();

        public GameService(
            WinCondition winCondition,
            LoseCondition loseCondition,
            SignalBus eventBus,
            IStateSwitcher stateSwitcher)
        {
            _winCondition = winCondition;
            _loseCondition = loseCondition;
            _eventBus = eventBus;
            _stateSwitcher = stateSwitcher;
        }

        public void Initialize()
        {
            _eventBus
                .Subscribe<PlayerEnterArenaSignal>(_ => _stateSwitcher.TrySwitchState<PreBattleState>());

            _winCondition.Complited
                .Subscribe(_ => OnWin())
                .AddTo(_disposables);

            _loseCondition.Complited
                .Subscribe(_ => OnLose())
                .AddTo(_disposables);

        }

        private void OnLose()
        {
            _stateSwitcher.TrySwitchState<LoseState>();
        }

        private void OnWin()
        {
            _stateSwitcher.TrySwitchState<WinState>();
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

    }
}
