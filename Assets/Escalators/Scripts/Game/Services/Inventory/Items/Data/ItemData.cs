using Assets.CodeCore.Scripts.Game.Providers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Items.Data
{
    public abstract class ItemData : ScriptableObjectGameData
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _description;

        public Sprite Icon => _icon;
        public string Description => _description;
    }
}
