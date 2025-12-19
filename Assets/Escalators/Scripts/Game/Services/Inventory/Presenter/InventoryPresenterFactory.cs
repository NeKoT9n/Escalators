using Inventory;
using Zenject;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Presenters.Inventory
{
    public class InventoryPresenterFactory
        : PlaceholderFactory<IReadOnlyInventoryGrid, InventoryView, InventoryPresenter> { }
}
