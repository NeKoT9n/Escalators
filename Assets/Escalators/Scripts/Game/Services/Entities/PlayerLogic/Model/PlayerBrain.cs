using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic
{
    public class PlayerBrain : Brain
    {
        private readonly IInputService _inputService;
        private readonly IMover _mover;
        
        public PlayerBrain(IInputService inputService, IMover mover)
        {
            _inputService = inputService;
            _mover = mover;
        }

        public override void Update() 
        {
            _mover?.Move(_inputService.MoveDirection.Value, Time.deltaTime);
        }

    }
}
