
using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Providers.Assets;
using Cysharp.Threading.Tasks;

namespace Assets.Escalators.Scripts.Game.Services.Obstacles.Spawner
{
    public class ObstacleDataProvider : IAsyncInitializable
    {
        public ObstacleData Data { get; private set; }
        private readonly IAssetProvider _assetProvider;

        public ObstacleDataProvider(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public async UniTask Initialize()
        {
            Data = await _assetProvider.Load<ObstacleData>(nameof(ObstacleData));
        }
    }
}
