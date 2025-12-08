using System;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.LoadLevel.Data
{
    [Serializable]
    public class RoadData
    {
        public float MoveSpeedMin = 3f;
        public float MoveSpeedMax = 6f;
        public float SpawnInterval = 2f;

    }

    [Serializable]
    public class TrackData
    {
        public List<RoadData> Roads;
    }

    [Serializable]
    public class LevelBuildData
    {
        public Vector3 StartPosition;
        public AssetReferenceGameObject StartPlacePrefab;
        public AssetReferenceGameObject ArenaPrefab;
        public AssetReferenceGameObject RoadPrefab;
        public List<TrackData> Tracks;
    }

}
