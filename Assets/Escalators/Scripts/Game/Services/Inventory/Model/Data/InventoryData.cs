using Assets.CodeCore.Scripts.Game.Providers;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName ="Data/Inventory", fileName = nameof(InventoryData))]
    public class InventoryData : ScriptableObjectGameData
    {
        [SerializeField] private Vector2Int _size = new Vector2Int(9, 9);
        [SerializeField] private SlotData _slotData;
        [SerializeField] private InventoryTypeId _id;

        public InventoryTypeId Id => _id;
        public SlotData SlotData => _slotData;
        public Vector2Int Size => _size;
    }
}
