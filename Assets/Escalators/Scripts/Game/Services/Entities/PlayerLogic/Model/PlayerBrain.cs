using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Startup.GameStates;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States;
using System.Collections.Generic;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic
{
    public class PlayerBrain : Brain, IInitializable
    {
        private readonly PlayerStateMachine _playerStateMachine;

        private readonly CompositeDisposable _disposables = new();

        public PlayerBrain(PlayerStateMachine playerStateMachine)
        {
            _playerStateMachine = playerStateMachine;
        }

        public void Initialize()
        {          
            _playerStateMachine.TrySwitchState<EntityFindTargetState>();
        }

        public override void Update() 
        {
            _playerStateMachine?.Update();
        }

    }
}
