using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using Assets.Escalators.Scripts.Game.Services.Level.LevelParts.Arenas;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Escalators.Scripts.Core.View
{
    public class ArenaView : LevelViewPart, IWorldView
    {
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private ArenaTrigger _arenaTrigger;

        public ArenaTrigger ArenaTrigger => _arenaTrigger;
        public List<Transform> SpawnPoints => _spawnPoints;
        public GameObject GameObject => gameObject;
    }
}
