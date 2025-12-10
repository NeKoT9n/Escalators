using Assets.CodeCore.Scripts.Game.Providers.Assets;
using Assets.CodeCore.Scripts.Game.Services;

namespace Assets.CodeCore.Scripts.Game.Providers.Level
{

    public class LevelDataProvider : GameDataProvider<LevelData>
    {
        public LevelDataProvider(IAssetProvider assetProvider) 
            : base(assetProvider) { }

        protected override string AssetName => "1_LevelData";
    }
}
