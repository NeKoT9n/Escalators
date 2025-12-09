using Assets.Escalators.Scripts.Core.Services.Update;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Obstacles.Model;

namespace Assets.CodeCore.Scripts.Game.Startup.GameStates.States
{
    public class CrossingRoadsState : IEnterableState
    {
        private readonly IPlayerService _playerService;
        private readonly IUpdateService _updateService;
        private readonly IObstacleService _obstacleService;

        public CrossingRoadsState(
            IPlayerService playerService,
            IUpdateService updateService,
            IObstacleService obstacleService)
        {
            _playerService = playerService;
            _updateService = updateService;
            _obstacleService = obstacleService;
        }

        public void Enter()
        {
            _updateService.Start();
            _obstacleService.StartSpawnObstacles();

            _playerService.Appear();
        }
    }
}
