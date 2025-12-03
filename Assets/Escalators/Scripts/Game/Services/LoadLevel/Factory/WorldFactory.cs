using Assets.CodeCore.Scripts.Game.Providers.Assets;
using Assets.CodeCore.Scripts.Game.Providers.Entities;
using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Assets.CodeCore.Scripts.Game.Services
{
    public class WorldFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IEntityDataProvider _entityDataProvider;
        private readonly DiContainer _diContainer;

        public WorldFactory(
            IAssetProvider assetProvider,
            IEntityDataProvider entityDataProvider,
            DiContainer diContainer)
        {
            _assetProvider = assetProvider;
            _entityDataProvider = entityDataProvider;
            _diContainer = diContainer;
        }

        public async UniTask<TView> CreateEntity<TView>(AssetReferenceGameObject reference, Vector2 position)
            where TView: class, IWorldView
        {
            GameObject prefab = await _assetProvider.LoadGameObject<GameObject>(reference)
                ?? throw new Exception($"Loading prefab error {reference.RuntimeKey}"); 

            TView component = _diContainer
                .InstantiatePrefab(prefab, position, Quaternion.identity, null)
                .GetComponent<TView>()
                ?? throw new Exception($"Component {typeof(TView)} not found on prefab {reference.RuntimeKey}");

            return component; 
        }


    }
}