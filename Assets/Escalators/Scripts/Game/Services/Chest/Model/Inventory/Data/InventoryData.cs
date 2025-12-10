using Assets.CodeCore.Scripts.Game.Providers;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName ="Data/Inventory", fileName = nameof(InventoryData))]
    public class InventoryData : ScriptableObjectGameData
    {
        [SerializeField] private int _size = 9;
        [SerializeField] private SlotData _slotData;

        public SlotData SlotData => _slotData;
        public int Size => _size;
    }
}
