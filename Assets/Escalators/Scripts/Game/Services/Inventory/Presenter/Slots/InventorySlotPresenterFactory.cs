using Inventory;
using Zenject;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Presenters.Inventory.Slots
{
    public class InventorySlotPresenterFactory
        : PlaceholderFactory<IReadOnlyInventorySlot, SlotView, SlotPresenter> { }
}
