using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Inventory
{
    public interface IReadOnlyInventorySlot
    {
        public IReadOnlyReactiveProperty<Item> Item { get; }
        public AssetReferenceGameObject Prefab { get; }
        public bool IsEmpty { get; }
        Vector2Int Position { get; }
    }
}
