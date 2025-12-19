using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using Inventory;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory
{
    public class InventoryBuilder
    {
        private readonly IInventoryService _inventoryService;
        private readonly IEnumerable<IInventoryBuildProfile> _profiles;

        public InventoryBuilder(
            IInventoryService inventoryService,
            IEnumerable<IInventoryBuildProfile> profiles)
        {
            _inventoryService = inventoryService;
            _profiles = profiles;
        }

        public void Build()
        {
            foreach(var profile in _profiles)
            {
                var cellGrid = profile.Build();
                _inventoryService.RegisterInventory(cellGrid);
            }
        }
    }

    public interface IInventoryBuildProfile
    {
        public CellGrid Build();
    }

    public class PlayerInventoryBuilder : IInventoryBuildProfile, IInitializable
    {
        private readonly IGameDataProvider<InventoryDataList> _dataProvider;
        private InventoryData _playerInventoryData;

        public PlayerInventoryBuilder(IGameDataProvider<InventoryDataList> dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void Initialize()
        {        
            var dataList = _dataProvider.Data;
            _playerInventoryData = dataList.Datas.First(data => data.Id == InventoryTypeId.Player);
        }

        public CellGrid Build()
        {
            IItemPlacementRule acceptRule = new DefaultSlotRule();
            return new(_playerInventoryData, acceptRule);
        }

    }

    public class ChestInventoryBuilder : IInventoryBuildProfile, IInitializable
    {
        private readonly IGameDataProvider<InventoryDataList> _dataProvider;
        private InventoryData _chestInventoryData;

        public ChestInventoryBuilder(IGameDataProvider<InventoryDataList> dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void Initialize()
        {
            var dataList = _dataProvider.Data;
            _chestInventoryData = dataList.Datas.First(data => data.Id == InventoryTypeId.Chest);
        }
        public CellGrid Build()
        {
            IItemPlacementRule acceptRule = new KeyTypeSlotRule(KeyTypeId.Red);
            return new(_chestInventoryData, acceptRule);
        }
    }
}
