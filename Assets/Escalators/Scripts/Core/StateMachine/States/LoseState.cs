using Assets.CodeCore.Scripts.Game.Startup.GameStates;
using Assets.Escalators.Scripts.Core.Services.Update;
using UnityEngine;

namespace Assets.CodeCore.Scripts.Game.Infostracture.StateMachine.States
{
    public class LoseState : IEnterableState
    {
        private readonly IUpdateService _updateService;

        public LoseState(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        public void Enter()
        {
            _updateService.Stop();
            Debug.Log("Lose");
        }
    }
}




