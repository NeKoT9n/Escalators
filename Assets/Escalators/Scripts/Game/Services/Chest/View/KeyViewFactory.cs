using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Services;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Items.Data;
using Cysharp.Threading.Tasks;
using Inventory;
using System;
using System.Collections.Generic;

namespace Assets.Escalators.Scripts.Game.Services.Chest.View
{
    public class ItemViewFactory : IInitializable
    {
        private readonly IGameDataProvider<KeyDataList> _keyDataProvider;
        private readonly WorldFactory _worldFactory;

        Dictionary<KeyTypeId, KeyData> _dataMap = new();

        public ItemViewFactory(IGameDataProvider<KeyDataList> keyDataProvider, WorldFactory worldFactory)
        {
            _keyDataProvider = keyDataProvider;
            _worldFactory = worldFactory;
        }

        public void Initialize()
        {
            var dataList = _keyDataProvider.Data;

            foreach (var data in dataList.Keys)
            {
                _dataMap.Add(data.KeyTypeId, data); 
            }
        }

        public async UniTask<ItemView> Create(Item item)
        {
            var view = await _worldFactory.Create<ItemView>(item.Prefab);

            return view;
        }


    }
}
