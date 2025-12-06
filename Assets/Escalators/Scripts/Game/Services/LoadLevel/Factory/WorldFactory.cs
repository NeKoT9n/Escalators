using Assets.CodeCore.Scripts.Game.Providers.Assets;
using Assets.CodeCore.Scripts.Game.Providers.Entities;
using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.View;
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
        private readonly IEntityDataContainer _entityDataProvider;
        private readonly DiContainer _diContainer;

        public WorldFactory(
            IAssetProvider assetProvider,
            IEntityDataContainer entityDataProvider,
            DiContainer diContainer)
        {
            _assetProvider = assetProvider;
            _entityDataProvider = entityDataProvider;
            _diContainer = diContainer;
        }

        public async UniTask<TView> Create<TView>(
            AssetReferenceGameObject reference,
            Vector3 position,
            Quaternion rotation,
            bool isActive = true)
                where TView : class, IWorldView
        {
            MonoBehaviour prefab = await _assetProvider.LoadGameObject<MonoBehaviour>(reference)
                ?? throw new Exception($"Loading prefab error {reference.RuntimeKey}");

            TView component = _diContainer
                .InstantiatePrefab(prefab.gameObject, position, rotation, null)
                .GetComponent<TView>()
                ?? throw new Exception($"Component {typeof(TView)} not found on prefab {reference.RuntimeKey}");

            component.GameObject.SetActive(isActive);

            return component;
        }

        public async UniTask<TView> Create<TView>(
            AssetReferenceGameObject reference,
            Vector3 position,
            bool isActive = true)
                   where TView : class, IWorldView
        {
            return await Create<TView>(reference, position, Quaternion.identity ,isActive);
        }

        public async UniTask<TView> Create<TView>(
            AssetReferenceGameObject reference,
            bool isActive = true)
           where TView : class, IWorldView
        {
            return await Create<TView>(reference, Vector3.zero, Quaternion.identity, isActive);
        }
    }
}