using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Items.Data;
using Inventory;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory
{
    public class InventoryRandomKeyFiller : IInventoryFiller,  IInitializable
    {
        private readonly IGameDataProvider<KeyDataList> _dataProvider;
        private readonly IInventoryService _inventoryService;
        private List<KeyData> _keyDatas;

        public InventoryRandomKeyFiller(
            IGameDataProvider<KeyDataList> dataProvider,
            IInventoryService inventoryService)
        {
            _dataProvider = dataProvider;
            _inventoryService = inventoryService;
        }

        public void Initialize()
        {
            var data = _dataProvider.Data;
            _keyDatas = data.Keys.ToList();  
        }

        public void Fill()
        {
            var grid = _inventoryService.Grid;

            //while (grid.IsFull() == false)
            //{
            //    var keyData = GetRandomKeyData();
            //    var item = new Key(keyData);

            //    _inventoryService.TryAddItem(item);
            //}

            for (int i = 0; i < 20; i++)
            {
                var keyData = GetRandomKeyData();
                var item = new Key(keyData);

                _inventoryService.TryAddItem(item);
            }

        }

        private KeyData GetRandomKeyData()
        {
            var keyIndex = Random.Range(0, _keyDatas.Count);

            return _keyDatas[keyIndex];
        }
    }

    public interface IInventoryFiller
    {
        public void Fill();
    }
}
