using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using UnityEngine;

namespace Inventory
{
    public class InventoryService : IInventoryService, IInitializable
    {
        public IReadOnlyInventoryGrid Grid => _grid;

        private readonly IGameDataProvider<InventoryData> _dataProvider;
        private CellGrid _grid;

        public InventoryService(IGameDataProvider<InventoryData> dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void Initialize()
        {
            var data = _dataProvider.Data;
            _grid = new(data);
        }

        public bool TryAddItem(Vector2Int cell, Item item)
        {
            return _grid.TryAddItem(cell, item);
        }

        public bool TryAddItem(Item item)
        {
            return _grid.TryAddItem(item);
        }

    }
}
