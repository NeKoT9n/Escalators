using Assets.CodeCore.Scripts.Game.Providers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data
{
    [CreateAssetMenu(menuName = "Data/Inventory/Slot", fileName = nameof(SlotData))]
    public class SlotData : ScriptableObjectGameData
    {
        [SerializeField] private AssetReferenceGameObject _prefab;

        public AssetReferenceGameObject Prefab => _prefab;
    }
}
