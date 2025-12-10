using Assets.CodeCore.Scripts.Game.Providers.Assets;
using Assets.CodeCore.Scripts.Game.Services.Entitieys.Data;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.CodeCore.Scripts.Game.Providers.Entities
{
    [CreateAssetMenu(fileName = "EntityDataProvider", menuName = "Data/Providers/EntityDataProvider")]
    public class EntityDataProvider : ScriptableObject
    {
        [SerializeField] private List<AssetReferenceT<EntityData>> _references;

        public async UniTask<List<EntityData>> Initialize(IAssetProvider assetProvider)
        {
            var datas = new List<EntityData>(_references.Count);

            foreach (var dataReference in _references)
            {
                var data = await assetProvider.Load<EntityData>(dataReference);
                datas.Add(data);
            }

            return datas;
        }

    }
}
