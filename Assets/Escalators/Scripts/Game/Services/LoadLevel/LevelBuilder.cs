using Assets.CodeCore.Scripts.Game.Services;
using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using Assets.Escalators.Scripts.Core.View;
using Assets.Escalators.Scripts.Game.Services.LoadLevel.Data;
using Cysharp.Threading.Tasks;
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

        public async UniTask Build(LevelBuildData buildData)
        {
            _targetSpawnPosition = buildData.StartPosition;

            await SpawnAndAlignByStartAnchor<StartPlace>(buildData.StartPlacePrefab);

            foreach(var trackData in buildData.Tracks)
            {
                foreach(var roadData in trackData.Roads)
                {
                    await SpawnAndAlignByStartAnchor<Road>(buildData.RoadPrefab);
                }

                await SpawnAndAlignByStartAnchor<Arena>(buildData.ArenaPrefab);
            }
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
