using Assets.CodeCore.Scripts.Game.Providers.Assets;
using Assets.CodeCore.Scripts.Game.Providers.Level;

namespace Assets.Escalators.Scripts.Game.Services.Obstacles.Spawner
{
    public class ObstacleDataProvider : GameDataProvider<ObstacleData>
    {
        public ObstacleDataProvider(IAssetProvider assetProvider) 
            : base(assetProvider) { }

        protected override string AssetName => nameof(ObstacleData);
    }
}
