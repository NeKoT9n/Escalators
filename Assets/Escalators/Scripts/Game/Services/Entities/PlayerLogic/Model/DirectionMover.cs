using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using UnityEngine;

public class DirectionMover : IMover
{

    public void Move(Entity entity, Vector2 direction, float deltaTime)
    {

        if (direction.sqrMagnitude < 0.01f)
        {
            entity.IsMoving.Value = false;
            return;
        }

        entity.IsMoving.Value = true;

        Vector3 directionInWorld = new Vector3(direction.x, 0, direction.y).normalized;
        Vector3 newPosition = entity.Position.Value + directionInWorld * entity.MoveSpeed * deltaTime;

        entity.Position.Value = newPosition;
        entity.Rotation.Value = Quaternion.LookRotation(directionInWorld);
    }
}


