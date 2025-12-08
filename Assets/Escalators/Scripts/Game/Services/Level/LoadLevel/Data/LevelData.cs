using Assets.CodeCore.Scripts.Game.Helpers;
using Assets.CodeCore.Scripts.Game.Providers;
using Assets.Escalators.Scripts.Game.Services.LoadLevel.Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.CodeCore.Scripts.Game.Services
{
    [CreateAssetMenu(menuName =("Data/LevelData"), fileName =("0_LevelData"))]
    public class LevelData : ScriptableObjectGameData
    {
        [SerializeField] private string _name;
        [SerializeField] private SpawnPoint _playerSpawnPoint;

        [SerializeField] private LevelBuildData _buildData;

        public SpawnPoint PlayerSpawnPoint => _playerSpawnPoint;
        public string Name => _name;
        public LevelBuildData BuildData => _buildData;

    }
}
