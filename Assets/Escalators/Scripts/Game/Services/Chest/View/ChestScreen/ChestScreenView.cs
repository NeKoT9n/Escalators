using Inventory;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Chest.View.ChestScreen
{
    public class ChestScreenView : MonoBehaviour
    {
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private ChestView _chestView;

        public InventoryView InventoryView => _inventoryView;
    }
}
