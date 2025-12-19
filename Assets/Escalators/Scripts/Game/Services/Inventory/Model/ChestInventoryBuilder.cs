using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Chests.Data;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using Inventory;
using System.Linq;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory
{
    public class ChestInventoryBuilder : IInventoryBuildProfile, IInitializable
    {
        private readonly IGameDataProvider<InventoryDataList> _dataProvider;
        private readonly IGameDataProvider<ChestData> _chestDataProvider;
        private InventoryData _chestInventoryData;

        public ChestInventoryBuilder(
            IGameDataProvider<InventoryDataList> dataProvider,
            IGameDataProvider<ChestData> chestDataProvider)
        {
            _dataProvider = dataProvider;
            _chestDataProvider = chestDataProvider;
        }

        public void Initialize()
        {
            var dataList = _dataProvider.Data;
            _chestInventoryData = dataList.Datas.First(data => data.Id == InventoryTypeId.Chest);
        }
        public CellGrid Build()
        {
            var keyType = _chestDataProvider.Data.Key;

            IItemPlacementRule acceptRule = new KeyTypeSlotRule(keyType);
            return new(_chestInventoryData, acceptRule);
        }
    }
}
