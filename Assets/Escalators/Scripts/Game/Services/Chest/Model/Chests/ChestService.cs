using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Chests.Data;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using Assets.Escalators.Scripts.Game.Services.Chest.Presenters;
using System;
using UniRx;
using UnityEngine;

namespace Inventory
{
    public class ChestService : IChestService, IInitializable, IDisposable
    {
        public IReactiveCommand<int> KeyAdded => _keyAdded;
        public IReactiveCommand<int> KeyRemoved => _keyRemoved;
        public IReactiveCommand<Unit> Opened => _opened;
        public IReactiveProperty<Sprite> Icon => _currentIcon;

        private ChestData _chestData; 

        private readonly ReactiveProperty<Sprite> _currentIcon = new();
        private readonly ReactiveCommand<int> _keyAdded = new();
        private readonly ReactiveCommand<int> _keyRemoved = new();
        private readonly ReactiveCommand<Unit> _opened = new();

        private readonly IInventoryService _inventoryService;
        private readonly IGameDataProvider<ChestData> _dataProvider;

        private readonly CompositeDisposable _disposables = new();

        private int _keyCount = 0;

        public ChestService(IInventoryService inventoryService, IGameDataProvider<ChestData> chestData)
        {
            _inventoryService = inventoryService;
            _dataProvider = chestData;
        }

        public void Initialize()
        {
            _chestData = _dataProvider.Data;
            _currentIcon.Value = _chestData.Defualt;

            _inventoryService.Registered
                .Subscribe(inventory =>
                {
                    if (inventory.Id == InventoryTypeId.Chest)
                        Subscribe(inventory);
                })
                .AddTo(_disposables);
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
