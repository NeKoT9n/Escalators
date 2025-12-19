using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using Inventory;
using System.Linq;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory
{
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
}
