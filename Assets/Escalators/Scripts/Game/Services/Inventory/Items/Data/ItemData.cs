using Assets.CodeCore.Scripts.Game.Providers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Items.Data
{
    public abstract class ItemData : ScriptableObjectGameData
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _description;
        [SerializeField] private AssetReferenceGameObject _prefab;

        public AssetReferenceGameObject Prefab => _prefab;
        public Sprite Icon => _icon;
        public string Description => _description;
    }
}
