using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Providers.Assets;
using Assets.CodeCore.Scripts.Game.Services.Entitieys.Data;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeCore.Scripts.Game.Providers.Entities
{
    public class EntityDataContainer : IEntityDataContainer, IAsyncInitializable
    {

        private readonly IAssetProvider _assetProvider;
        private readonly Dictionary<EntityTypeId, EntityData> _dataMap = new();

        public EntityData GetBy(EntityTypeId typeId)
        {
            if (_dataMap.TryGetValue(typeId, out var data) == false)
                throw new Exception($"No data for entity type: {typeId}.");

            return data;
        }

        public EntityDataContainer(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public async UniTask Initialize()
        {   
            EntityDataProvider provider = await _assetProvider
                .Load<EntityDataProvider>(nameof(EntityDataProvider));

            var datas = await provider.Initialize(_assetProvider);

            foreach(var data in datas)
                _dataMap.Add(data.Type, data);

        }
    }
}
