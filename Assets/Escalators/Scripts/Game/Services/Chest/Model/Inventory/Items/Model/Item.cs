using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Items.Data;
using UnityEngine;

namespace Inventory
{
    public class Item
    {
        public Sprite Icon => _itemData.Icon;
        public string Description => _itemData.Description;

        private readonly ItemData _itemData;

        public Item(ItemData itemData) 
        {
            _itemData = itemData;
        }
    }
}
