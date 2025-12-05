using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Services.Entitieys.Model;
using Assets.Escalators.Scripts.Game.Services.Camera;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Presenters;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.View;
using Cysharp.Threading.Tasks;
using System;
using UniRx;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters
{
    public class PlayerPresenter : IInitializable, IDisposable
    {
        private readonly IPlayerService _playerService;

        private PlayerView _playerView;
        private EntityPresenter _playerPresenter;

        private readonly EntityViewFactory _viewFactory;
        private readonly ICameraService _cameraService;
        private readonly CompositeDisposable _disposables = new();

        public PlayerPresenter(
            IPlayerService playerService,
            EntityViewFactory viewFactory,
            ICameraService cameraService)
        {
            _playerService = playerService;
            _viewFactory = viewFactory;
            _cameraService = cameraService;
        }

        public void Initialize()
        {
            _playerService.SpawnPlayer
                .Subscribe(async command =>
                {
                    await SpawnPlayer(command.Player);
                    command.Completion.TrySetResult();
                });
        }
        
        public async UniTask SpawnPlayer(Player player)
        {
            var view = await _viewFactory.Spawn(player);
            _playerView = (PlayerView)view;

            _cameraService.SetTarget(view.transform);
           
            _playerPresenter = new(player, _playerView);
            _playerPresenter.Initialize();
        }

        public void Dispose()
        {
            _playerPresenter.Dispose();
            _disposables.Dispose();
        }
    }

}
