using Assets.CodeCore.Scripts.Game.Services.Entitieys.Factory;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.View;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.CodeCore.Scripts.Game.Services.Entitieys.Model
{
    public interface IEntityViewFactoryPlugin : IFactoryPlugin<EntityTypeId>
    {
        public UniTask<EntityView> Create(AssetReferenceGameObject prefab, Vector2 position);
    }
}
