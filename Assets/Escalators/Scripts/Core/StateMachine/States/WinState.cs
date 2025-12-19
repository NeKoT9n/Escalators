using Assets.CodeCore.Scripts.Game.Services.Game;
using Assets.CodeCore.Scripts.Game.Startup.GameStates;
using Assets.Escalators.Scripts.Core.Services.Update;

namespace Assets.CodeCore.Scripts.Game.Infostracture.StateMachine.States
{
    public class WinState : IEnterableState
    {
        private readonly IUpdateService _updateService;
        private readonly IGameService _gameService;

        public WinState(IUpdateService updateService, IGameService gameService)
        {
            _updateService = updateService;
            _gameService = gameService;
        }

        public void Enter()
        {
            _updateService.Stop();
            _gameService.ShowWin();
        }
    }
}




