using Assets.CodeCore.Scripts.Game.Startup.GameStates;
using Assets.Escalators.Scripts.Core.Services.Update;
using System.Data;
using UnityEngine;

namespace Assets.CodeCore.Scripts.Game.Infostracture.StateMachine.States
{
    public class WinState : IEnterableState
    {
        private readonly IUpdateService _updateService;

        public WinState(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        public void Enter()
        {
            _updateService.Stop();

            Debug.Log("Win");
        }
    }
}




