using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Items.Data;
using Inventory;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory
{
    public class InventoryRandomKeyFiller : IInventoryFiller,  IInitializable
    {
        private readonly IGameDataProvider<KeyDataList> _dataProvider;
        private readonly IInventoryService _inventoryService;

        private readonly int _keyTypeCount = 3;
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
            var allTypes = Enum.GetValues(typeof(KeyTypeId)).Cast<KeyTypeId>().ToList();
            allTypes.Remove(KeyTypeId.None);

            List<Key> keys;

            while (true)
            {
                keys = CreateKeys(21);

                if (keys.Count < allTypes.Count * _keyTypeCount)
                    throw new Exception($"Inventory fill error");

                if(HasNescessaryTypeCount(allTypes, keys, _keyTypeCount))
                    break;
            }

            AddToInventory(InventoryTypeId.Player, keys);        
        }


        private List<Key> CreateKeys(int count)
        {
            List<Key> keys = new(count);
            for (int i = 0; i < count; i++)
            {
                var keyData = GetRandomKeyData();
                var item = new Key(keyData);

                keys.Add(item);
            }

            return keys;
        }

        private bool HasNescessaryTypeCount(IEnumerable<KeyTypeId> allTypes, List<Key> keys, int necessaryCount)
        {
            foreach (var id in allTypes)
            {

                if (HasNecessaryTypeCount(keys, id, necessaryCount) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private bool HasNecessaryTypeCount(List<Key> keys, KeyTypeId id, int necesseryCount)
        {
            var count = 0;

            foreach (var key in keys)
            {
                if(key.Type == id)
                    count++;

                if(count >= necesseryCount)
                    return true;
            }

            return false;
        }

        private void AddToInventory(InventoryTypeId id, List<Key> keys)
        {
            foreach(var key in keys)
            {
                _inventoryService.TryAddItem(InventoryTypeId.Player, key);
            }
        }

        private KeyData GetRandomKeyData()
        {
            var keyIndex = UnityEngine.Random.Range(0, _keyDatas.Count);

            return _keyDatas[keyIndex];
        }
    }

    public interface IInventoryFiller
    {
        public void Fill();
    }
}
