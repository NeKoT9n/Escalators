using Assets.CodeCore.Scripts.Game.UI.Base;
using Inventory;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Chest.View.ChestScreen
{
    public class ChestScreenView : UIBase
    {
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private ChestView _chestView;
        [SerializeField] private ItemView _dragItemView;

        public ItemView DragItemView => _dragItemView;
        public InventoryView InventoryView => _inventoryView;
        public ChestView ChestView => _chestView;
    }
}
