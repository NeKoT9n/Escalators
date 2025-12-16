using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Chest.View;
using Assets.Escalators.Scripts.Game.Services.Chest.View.ChestScreen;
using Inventory;
using System;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Presenters
{
    public class ChestPresenter : IInitializable
    {
        private readonly IChestService _chestService;
        private readonly ChestView _chestView;

        private readonly CompositeDisposable _disposables = new();

        public ChestPresenter(IChestService chestService, ChestScreenView chestScreenView)
        {
            _chestService = chestService;
            _chestView = chestScreenView.ChestView;
        }

        public void Initialize()
        {
            _chestService.Icon
                .Subscribe(icon => _chestView.SetIcon(icon))
                .AddTo(_disposables);

            _chestService.KeyAdded
                .Subscribe(keyCount => SetProgress(keyCount))
                .AddTo(_disposables); 
            
            _chestService.KeyRemoved
                .Subscribe(keyCount => SetProgress(keyCount))
                .AddTo(_disposables); 
            
            _chestService.Opened
                .Subscribe(_ => Open())
                .AddTo(_disposables);
        }

        private void SetProgress(int keyCount)
        {
            string progress = $"{keyCount}/3";

            _chestView.SetProgress(progress);
        }

        private void Open()
        {
            _chestView.Open();
        }

    }
}
