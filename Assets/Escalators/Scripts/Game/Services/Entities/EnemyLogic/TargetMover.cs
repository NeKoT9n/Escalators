using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.TargetFinder;
using UnityEngine;
using UniRx;

public class TargetMover : IMover
{
    private readonly ITargetFinder _targetFinder;
    private Transform _target;

    public TargetMover(ITargetFinder targetFinder)
    {
        _targetFinder = targetFinder;

        _targetFinder.Target
            .Where(target => target != null)
            .Subscribe(target => _target = target.transform);
        
        _targetFinder.Target
            .Where(target => target == null)
            .Subscribe(_ => _target = null);

    }

    public void Move(Entity entity, float deltaTime)
    {

        if(_target == null)
            return;

        //move
    }
}
