using IInitializable = Assets.CodeCore.Scripts.Game.Infostracture.IInitializable;
using Assets.Escalators.Scripts.Game.Services.Chest.Box;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Chests.Data;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using Assets.Escalators.Scripts.Game.Services.Chest.Presenters;
using System;
using UniRx;
using UnityEngine;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Items.Data;
using System.Linq;

namespace Inventory
{
    public class ChestService : IChestService, IInitializable, IDisposable
    {
        public IReactiveCommand<int> KeyAdded => _keyAdded;
        public IReactiveCommand<int> KeyRemoved => _keyRemoved;
        public IReactiveCommand<Unit> Opened => _opened;
        public IReactiveCommand<Unit> ShowUI => _showUI;
        public IReactiveProperty<Sprite> Icon => _currentIcon;
        public Color KeyColor { get; private set; }

        private ChestData _chestData; 

        private readonly ReactiveProperty<Sprite> _currentIcon = new();
        private readonly ReactiveCommand<int> _keyAdded = new();
        private readonly ReactiveCommand<int> _keyRemoved = new();
        private readonly ReactiveCommand<Unit> _opened = new();
        private readonly ReactiveCommand<Unit> _showUI = new();

        private readonly IInventoryService _inventoryService;
        private readonly IGameDataProvider<ChestData> _dataProvider;
        private readonly IGameDataProvider<KeyDataList> _keyDataListProvider;
        private readonly IEnemyService _enemyService;
        private readonly IChestBoxService _chestBoxService;
        private readonly CompositeDisposable _disposables = new();

        private int _keyCount = 0;

        public ChestService(
            IInventoryService inventoryService,
            IGameDataProvider<ChestData> chestData,
            IGameDataProvider<KeyDataList> keyDataListProvider,
            IEnemyService enemyService,
            IChestBoxService chestBoxService)
        {
            _inventoryService = inventoryService;
            _dataProvider = chestData;
            _keyDataListProvider = keyDataListProvider;
            _enemyService = enemyService;
            _chestBoxService = chestBoxService;
        }

        public void Initialize()
        {
            _chestData = _dataProvider.Data;

            KeyData keyData = _keyDataListProvider.Data.Keys.
                FirstOrDefault(keyData => keyData.KeyTypeId == _chestData.Key);

            _currentIcon.Value = _chestData.Defualt;
            KeyColor = keyData.Color;

            _inventoryService.Registered
                .Subscribe(inventory =>
                {
                    if (inventory.Id == InventoryTypeId.Chest)
                        Subscribe(inventory);
                })
                .AddTo(_disposables);

            _enemyService.DiedAll
                .Subscribe(_ => OnAllEnemyDied())
                .AddTo(_disposables);
        }

        private async void OnAllEnemyDied()
        {
            await _chestBoxService.SpawnAsync();
            _showUI.Execute(Unit.Default);
        }

        private void Subscribe(IReadOnlyInventoryGrid inventory)
        {
            inventory.ItemAdded
                .Subscribe(data => OnItemAdded(data))
                .AddTo(_disposables);

            inventory.ItemRemoved
                .Subscribe(data => OnItemRemoved(data))
                .AddTo(_disposables);
        }

        private void OnItemAdded(ItemAddCommand _)
        {
            _keyAdded.Execute(++_keyCount);

            if(_keyCount == 3)
            {
                _currentIcon.Value = _chestData.Opened;
                _opened.Execute(Unit.Default);
            }
        }

        private void OnItemRemoved(ItemRemoveCommand _)
        {
            _keyRemoved.Execute(--_keyCount);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
