using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using UnityEngine;

namespace Assets.Escalators.Scripts.Core.View
{
    public class RoadView : LevelViewPart, IWorldView
    {
        [SerializeField] private Transform _leftSpawner;
        [SerializeField] private Transform _rightSpawner;

        public Transform LeftSpawnerPosition => _leftSpawner;
        public Transform RightSpawnerPosition => _rightSpawner;

        public GameObject GameObject => gameObject;

    }

}
