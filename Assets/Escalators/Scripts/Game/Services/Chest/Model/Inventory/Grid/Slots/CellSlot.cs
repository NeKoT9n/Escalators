using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using UniRx;
using UnityEngine.AddressableAssets;

namespace Inventory
{
    public class CellSlot : IReadOnlyInventorySlot
    {
        public IReadOnlyReactiveProperty<Item> Item => _item;
        public AssetReferenceGameObject Prefab => _data.Prefab;
        public bool IsEmpty => _item.Value == null;


        private readonly ReactiveProperty<Item> _item = new();
        private readonly SlotData _data;

        public CellSlot(SlotData data)
        {
            _data = data;
        }

        public void SetItem(Item item)
        {
            _item.Value = item;
        }

        public Item RemoveItem()
        {
            var removedItem = _item.Value;
            _item.Value = null;

            return removedItem;
        }
    }
}
