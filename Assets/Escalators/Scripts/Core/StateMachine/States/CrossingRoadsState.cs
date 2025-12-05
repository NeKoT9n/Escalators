using Assets.Escalators.Scripts.Core.Services.Update;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;

namespace Assets.CodeCore.Scripts.Game.Startup.GameStates.States
{
    public class CrossingRoadsState : IEnterableState
    {
        private readonly IPlayerService _playerService;
        private readonly IUpdateService _updateService;

        public CrossingRoadsState(IPlayerService playerService, IUpdateService updateService)
        {
            _playerService = playerService;
            _updateService = updateService;
        }

        public void Enter()
        {
            _updateService.Start();

            _playerService.Appear();
        }
    }
}
