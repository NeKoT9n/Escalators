using Inventory;
using System.Collections.Generic;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory
{
    public class InventoryBuilder
    {
        private readonly IInventoryService _inventoryService;
        private readonly IEnumerable<IInventoryBuildProfile> _profiles;

        public InventoryBuilder(
            IInventoryService inventoryService,
            IEnumerable<IInventoryBuildProfile> profiles)
        {
            _inventoryService = inventoryService;
            _profiles = profiles;
        }

        public void Build()
        {
            foreach(var profile in _profiles)
            {
                var cellGrid = profile.Build();
                _inventoryService.RegisterInventory(cellGrid);
            }
        }
    }
}
