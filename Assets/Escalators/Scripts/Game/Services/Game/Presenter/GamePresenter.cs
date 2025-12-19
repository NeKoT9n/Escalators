using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Services.Game;
using Assets.Escalators.Scripts.Core.UI;
using System;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Game.Presenter
{
    public class GamePresenter : IInitializable, IDisposable
    {
        private readonly IGameService _gameService;
        private readonly ScreenView _screenView;

        private readonly CompositeDisposable _disposables = new();
        public GamePresenter(IGameService gameService, ScreenView screenView)
        {
            _gameService = gameService;
            _screenView = screenView;
        }

        public void Initialize()
        {
            _gameService.Win
                .Subscribe(_ => _screenView.ShowWinPanel())
                .AddTo(_disposables);

            _gameService.Lose
                .Subscribe(_ => _screenView.ShowLosePanel())
                .AddTo(_disposables);

            _screenView.RestertButtonClicked
                .Subscribe(_ => _gameService.Restart())
                .AddTo(_disposables);

        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
