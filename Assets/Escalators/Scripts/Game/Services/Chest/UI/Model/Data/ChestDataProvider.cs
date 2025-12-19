using Assets.CodeCore.Scripts.Game.Providers.Assets;
using Assets.CodeCore.Scripts.Game.Providers.Level;
using Cysharp.Threading.Tasks;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Model.Chests.Data
{
    public class ChestDataProvider : GameDataProvider<ChestData>
    {
        public ChestDataProvider(IAssetProvider assetProvider) : base(assetProvider) { }

        protected override string AssetName => nameof(ChestData);

        public async override UniTask Initialize()
        {
            await base.Initialize();
            _data.SetRandomKeyType();
        }
    }
}
