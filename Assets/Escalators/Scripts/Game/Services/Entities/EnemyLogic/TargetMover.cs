using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.TargetFinder;
using UnityEngine;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;

public class TargetMover : IMover
{
    private readonly Entity _entity;
    private readonly ITargetFinder _targetFinder;

    public TargetMover(Entity entity, ITargetFinder targetFinder)
    {
        _entity = entity;
        _targetFinder = targetFinder;
    }

    public void LookAt(Vector3 at)
    {
        Vector3 direction = at - _entity.Position.Value;
        direction.y = 0;

        LookDirection(direction);
    }

    public void Move()
    {
        Transform target = _targetFinder.Target.Value.transform;

        if (target == null)
            return;

        Vector3 currentPos = _entity.Position.Value;
        Vector3 targetPos = target.position;
        targetPos.y = currentPos.y;

        var direction = (targetPos - currentPos).normalized;

        float step = _entity.MoveSpeed * Time.deltaTime;
        Vector3 nextPosition = Vector3.MoveTowards(currentPos, targetPos, step);

        _entity.Position.Value = nextPosition;
        _entity.IsMoving.Value = true;

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
