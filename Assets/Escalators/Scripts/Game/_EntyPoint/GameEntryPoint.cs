using Assets.CodeCore.Scripts.Game.Infostracture.Factories;
using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine;
using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine.States;
using Assets.CodeCore.Scripts.Game.Startup.GameStates;
using Assets.CodeCore.Scripts.Game.Startup.GameStates.States;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


namespace Assets.CodeCore.Scripts.Game.Startup
{
    public class GameEntryPoint : MonoBehaviour
    {
        [Inject] readonly GameStateMachine _stateMachine;
        [Inject] readonly GameStateFactory _gameStateFactory;

        public void Awake()
        {
            _stateMachine.Initialize(new List<IState>()
            {
                _gameStateFactory.CreateState<InitializeState>(),
                _gameStateFactory.CreateState<LoadLevelState>(),
                _gameStateFactory.CreateState<CrossingRoadsState>(),
                _gameStateFactory.CreateState<PreBattleState>(),
                _gameStateFactory.CreateState<BattleState>(),
                _gameStateFactory.CreateState<ChestInteractionState>(),
                _gameStateFactory.CreateState<WinState>(),
                _gameStateFactory.CreateState<LoseState>(),
                _gameStateFactory.CreateState<PauseState>()
            });

            _stateMachine.TrySwitchState<InitializeState>();
        }

        public void Update()
        {
            _stateMachine.Update();
        }

        public void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }
    }
}
