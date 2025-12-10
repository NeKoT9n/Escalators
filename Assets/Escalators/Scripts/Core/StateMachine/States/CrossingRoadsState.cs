using Assets.Escalators.Scripts.Core.Services.Update;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Items.Data;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Obstacles.Model;
using Inventory;

namespace Assets.CodeCore.Scripts.Game.Startup.GameStates.States
{
    public class CrossingRoadsState : IEnterableState
    {
        private readonly IPlayerService _playerService;
        private readonly IUpdateService _updateService;
        private readonly IObstacleService _obstacleService;
        private readonly IInventoryService _inventoryService;

        public CrossingRoadsState(
            IPlayerService playerService,
            IUpdateService updateService,
            IObstacleService obstacleService,
            IInventoryService inventoryService)
        {
            _playerService = playerService;
            _updateService = updateService;
            _obstacleService = obstacleService;
            _inventoryService = inventoryService;
        }

        public void Enter()
        {
            _updateService.Start();
            _obstacleService.StartSpawnObstacles();

            _playerService.Appear();

            KeyData data = new();
            Item test = new(data);

            _inventoryService.TryAddItem(test);
        }
    }
}
