using System;
using UniRx;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture
{
    public interface IInputService
    {
        public IReadOnlyReactiveProperty<Vector2> MoveDirection { get; }
    }
}
