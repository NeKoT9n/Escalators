using Assets.CodeCore.Scripts.Game.Helpers;
using Assets.CodeCore.Scripts.Game.Providers;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeCore.Scripts.Game.Services
{
    [CreateAssetMenu(menuName =("Data/LevelData"), fileName =("0_LevelData"))]
    public class LevelData : ScriptableObjectGameData
    {
        [SerializeField] private string _name;
        [SerializeField] private SpawnPoint _playerSpawnPoint;

        public SpawnPoint PlayerSpawnPoint => _playerSpawnPoint;
        public string Name => _name;

    }
}
