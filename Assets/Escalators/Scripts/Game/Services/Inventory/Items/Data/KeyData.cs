using Inventory;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Items.Data
{
    [CreateAssetMenu(menuName = "Data/InventoryItems/Key", fileName = nameof(KeyData))]
    public class KeyData : ItemData
    {
        [SerializeField] private KeyTypeId _keyType; 
        [SerializeField] private Color _color; 
        public KeyTypeId KeyTypeId => _keyType;
        public Color Color => _color;
    }
}
