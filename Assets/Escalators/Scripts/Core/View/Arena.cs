using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Escalators.Scripts.Core.View
{
    public class Arena : LevelViewPart, IWorldView
    {
        [SerializeField] private List<Transform> _spawnPoints;

        public List<Transform> SpawnPositions => _spawnPoints;

        public GameObject GameObject => gameObject;
    }
}
