using IInitializable = Assets.CodeCore.Scripts.Game.Infostracture.IInitializable;
using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine;
using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine.States;
using Assets.CodeCore.Scripts.Game.View;
using System;
using UniRx;
using Zenject;
using Assets.Escalators.Scripts.Game.Services.Level.LevelParts.Arenas;
using Assets.CodeCore.Scripts.Game.Startup.GameStates.States;
using Assets.CodeCore.Scripts.Game.Services.SceneLoad;

namespace Assets.CodeCore.Scripts.Game.Services.Game
{
    public class GameService : IInitializable, IDisposable, IGameService
    {
        public IReactiveCommand<Unit> Win => _win;
        public IReactiveCommand<Unit> Lose => _lose;

        private readonly WinCondition _winCondition;
        private readonly LoseCondition _loseCondition;
        private readonly SignalBus _eventBus;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly SceneLoadService _sceneLoader;

        private readonly ReactiveCommand<Unit> _win = new();
        private readonly ReactiveCommand<Unit> _lose = new();

        private readonly CompositeDisposable _disposables = new();

        public GameService(
            WinCondition winCondition,
            LoseCondition loseCondition,
            SignalBus eventBus,
            IStateSwitcher stateSwitcher,
            SceneLoadService sceneLoader)
        {
            _winCondition = winCondition;
            _loseCondition = loseCondition;
            _eventBus = eventBus;
            _stateSwitcher = stateSwitcher;
            _sceneLoader = sceneLoader;
        }

        public void Initialize()
        {
            _eventBus
                .Subscribe<PlayerEnterArenaSignal>(_ => _stateSwitcher.TrySwitchState<PreBattleState>());

            _winCondition.Complited
                .Subscribe(_ => OnWinConditionComplite())
                .AddTo(_disposables);

            _loseCondition.Complited
                .Subscribe(_ => OnLoseConditionComplite())
                .AddTo(_disposables);

        }

        private void OnLoseConditionComplite()
        {
            _stateSwitcher.TrySwitchState<LoseState>();
        }

        private void OnWinConditionComplite()
        {
            _stateSwitcher.TrySwitchState<WinState>();
        }

        public void ShowWin()
        {
            Win.Execute(Unit.Default);
        }

        public void ShowLose()
        {
            Lose.Execute(Unit.Default);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        public void Restart()
        {
            _sceneLoader.RestartLevel();
        }
    }
}
