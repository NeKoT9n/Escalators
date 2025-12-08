using Assets.CodeCore.Scripts.Game.Services;
using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using Assets.Escalators.Scripts.Core.View;
using Assets.Escalators.Scripts.Game.Services.Level.LevelParts.Arenas;
using Assets.Escalators.Scripts.Game.Services.Level.LevelParts.Roads;
using Assets.Escalators.Scripts.Game.Services.Level.Tracks.Model;
using Assets.Escalators.Scripts.Game.Services.LoadLevel.Data;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Escalators.Scripts.Game.Services.LoadLevel
{
    public class LevelBuilder : ILevelBuilder
    {
        private readonly WorldFactory _worldFactory;

        private Vector3 _targetSpawnPosition = Vector3.zero;

        public LevelBuilder(WorldFactory worldFactory)
        {
            _worldFactory = worldFactory;
        }

        public async UniTask<LevelBuildedData> Build(LevelBuildData buildData)
        {
            LevelBuildedData result = new() { Tracks = new() };

            _targetSpawnPosition = buildData.StartPosition;

            var startView = await SpawnAndAlignByStartAnchor<StartPlaceView>(buildData.StartPlacePrefab);

            result.StartPlace.Model = new(
                startView.PlayerSpawnPosition,
                startView.transform.position);

            result.StartPlace.View = startView;

            List<Track> tracks = new();

            foreach (var trackData in buildData.Tracks)
            {

                List<Road> roads = new();
                List<RoadView> roadViews = new();

                foreach(var roadData in trackData.Roads)
                {
                    var roadView = await SpawnAndAlignByStartAnchor<RoadView>(buildData.RoadPrefab);
                    var road = new Road(
                        roadData, roadView.LeftSpawnerPosition,
                        roadView.RightSpawnerPosition,
                        roadView.transform.position);

                    roads.Add(road);
                    roadViews.Add(roadView);
                }

                result.Tracks.Add(new TrackBuildedData()
                { 
                    Model = new Track(roads),
                    View = roadViews
                });

            }

            var arenaView = await SpawnAndAlignByStartAnchor<ArenaView>(buildData.ArenaPrefab);
            Arena arena = new(arenaView.SpawnPoints, arenaView.transform.position);

            result.Arena.Model = arena;
            result.Arena.View = arenaView;

            return result;
        }

        public async UniTask<T> SpawnAndAlignByStartAnchor<T>(
            AssetReferenceGameObject prefab)
            where T : LevelViewPart, IWorldView
        {
            var instance = await _worldFactory.Create<T>(prefab);
            var transform = instance.transform;

            Vector3 anchorStartWorld = transform.TransformPoint(instance.AnchorStart);

            Vector3 offset = anchorStartWorld - transform.position;

            transform.position = _targetSpawnPosition - offset;
            _targetSpawnPosition = transform.TransformPoint(instance.AnchorEnd);

            return instance;
        }

    }
}
