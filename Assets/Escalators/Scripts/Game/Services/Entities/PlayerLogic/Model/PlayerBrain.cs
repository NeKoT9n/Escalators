using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Model;

namespace Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic
{
    public class PlayerBrain : Brain
    {
        private readonly PlayerStateMachine _playerStateMachine;

        public PlayerBrain(PlayerStateMachine playerStateMachine)
        {
            _playerStateMachine = playerStateMachine;

            _playerStateMachine.TrySwitchState<PlayerFindTargetState>();
        }

        public override void Update() 
        {
            _playerStateMachine?.Update();
        }

    }
}
