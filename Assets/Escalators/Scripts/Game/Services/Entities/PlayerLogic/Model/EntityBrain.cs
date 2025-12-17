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
    public class EntityBrain : Brain, IInitializable
    {
        private readonly EntityStateMachine _playerStateMachine;

        private readonly CompositeDisposable _disposables = new();

        public EntityBrain(EntityStateMachine playerStateMachine)
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
