using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using UnityEngine;

namespace Assets.Escalators.Scripts.Core.View
{
    public class Road : LevelViewPart, IWorldView
    {
        [SerializeField] private Transform _leftSpawner;
        [SerializeField] private Transform _rightSpawner;

        public Vector3 LeftSpawnerPosition => _leftSpawner.position;
        public Vector3 RightSpawnerPosition => _rightSpawner.position;

        public GameObject GameObject => gameObject;

    }

}
