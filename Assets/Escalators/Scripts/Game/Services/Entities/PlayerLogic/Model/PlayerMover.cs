using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using UnityEngine;

public class PlayerMover : IMover
{
    private readonly Entity _model;

    public PlayerMover(Entity model)
    {
        _model = model;
    }

    public void Move(Vector2 input, float deltaTime)
    {
        if (input.sqrMagnitude < 0.01f)
        {
            _model.IsMoving.Value = false;
            return;
        }

        _model.IsMoving.Value = true;

        Vector3 direction = new Vector3(input.x, 0, input.y).normalized;
        Vector3 newPosition = _model.Position.Value + direction * _model.MoveSpeed;

        _model.Position.Value = newPosition;
        _model.Rotation.Value = Quaternion.LookRotation(direction);
    }
}


