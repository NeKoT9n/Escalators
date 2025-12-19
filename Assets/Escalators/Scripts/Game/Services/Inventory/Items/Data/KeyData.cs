using Inventory;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Items.Data
{
    [CreateAssetMenu(menuName = "Data/InventoryItems/Key", fileName = nameof(KeyData))]
    public class KeyData : ItemData
    {
        [SerializeField] private KeyTypeId _keyType; 
        public KeyTypeId KeyTypeId => _keyType;
    }
}
