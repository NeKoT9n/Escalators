using Assets.CodeCore.Scripts.Game.Services;
using Cysharp.Threading.Tasks;
using Inventory;

namespace Assets.Escalators.Scripts.Game.Services.Chest.View
{
    public class InventorySlotViewFactory
    {
        private readonly WorldFactory _worldFactory;

        public InventorySlotViewFactory(WorldFactory worldFactory)
        {
            _worldFactory = worldFactory;
        }
        public async UniTask<SlotView> Create(IReadOnlyInventorySlot data)
        {
            
            return await _worldFactory.Create<SlotView>(data.Prefab);
        }
    }

}
