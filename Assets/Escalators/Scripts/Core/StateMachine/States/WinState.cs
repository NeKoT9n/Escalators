using Assets.CodeCore.Scripts.Game.Startup.GameStates;
using UnityEngine;

namespace Assets.CodeCore.Scripts.Game.Infostracture.StateMachine.States
{
    public class WinState : IEnterableState
    {
        public void Enter()
        {
            Debug.Log("Win");
        }
    }
}




