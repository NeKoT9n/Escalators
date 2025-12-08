using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using UnityEngine;

namespace Assets.Escalators.Scripts.Core.View
{
    public class StartPlaceView : LevelViewPart, IWorldView
    {
        [SerializeField] private Transform _playerSpawnPosition;
        public Vector3 PlayerSpawnPosition => _playerSpawnPosition.position;

        public GameObject GameObject => gameObject;
    }
}
