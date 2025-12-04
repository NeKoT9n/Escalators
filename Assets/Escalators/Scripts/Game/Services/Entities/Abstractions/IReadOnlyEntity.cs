using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using UniRx;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Abstractions
{
    public interface IReadOnlyEntity
    {
        IReadOnlyReactiveProperty<Vector3> Position { get; }
        IReadOnlyReactiveProperty<Quaternion> Rotation { get; }
        IReadOnlyReactiveProperty<float> CurrentHealth { get; }
        IReadOnlyReactiveProperty<bool> IsDead { get; }
        IReadOnlyReactiveProperty<bool> IsMoving { get; }
        ReactiveCommand OnAttack { get; }
        float AttackRange { get; }

    }

}
