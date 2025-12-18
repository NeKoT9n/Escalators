using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using TMPro;
using UnityEngine;

public class InputMover : IMover
{
    private readonly Entity _entity;
    private readonly IInputService _inputService;

    public InputMover(Entity entity, IInputService inputService)
    {
        _entity = entity;
        _inputService = inputService;
    }

    public void LookAt(Vector3 at)
    {
        Vector3 direction = at - _entity.Position.Value;
        direction.y = 0;

        LookDirection(direction);
    }

    public void Move()
    {
        var input = _inputService.MoveDirection.Value;

        _entity.IsMoving.Value = true;

        var direction = new Vector3(input.x, 0, input.y).normalized;

        Vector3 newPosition = 
            _entity.Position.Value + 
            direction * 
            _entity.MoveSpeed * 
            Time.deltaTime;

        _entity.Position.Value = newPosition;
        LookDirection(direction);
    }

    private void LookDirection(Vector3 direction)
    {
        _entity.Rotation.Value = Quaternion.LookRotation(direction);
    }

    public void Stop()
    {
        _entity.IsMoving.Value = false;
    }
}


