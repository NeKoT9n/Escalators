using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using UnityEngine;

public class InputMover : IMover
{
    private readonly IInputService _inputService;

    public InputMover(IInputService inputService)
    {
        _inputService = inputService;
    }
    public void Move(Entity entity, float deltaTime)
    {
        var direction = _inputService.MoveDirection.Value;

        entity.IsMoving.Value = true;

        Vector3 directionInWorld = new Vector3(direction.x, 0, direction.y).normalized;
        Vector3 newPosition = entity.Position.Value + directionInWorld * entity.MoveSpeed * deltaTime;

        entity.Position.Value = newPosition;
        entity.Rotation.Value = Quaternion.LookRotation(directionInWorld);
    }
}


