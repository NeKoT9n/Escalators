using UniRx;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Level.Model
{
    public class Level
    {
        ReactiveProperty<Vector3> PlayerSpawnPosition { get; set; }

    }
}
