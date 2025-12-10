using Assets.CodeCore.Scripts.Game.Providers.Assets;
using Assets.CodeCore.Scripts.Game.Providers.Level;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;

namespace Assets.Escalators.Scripts.Core.Providers.Inventories
{
    internal class KeyDataListProvider : GameDataProvider<KeyDataList>
    {
        public KeyDataListProvider(IAssetProvider assetProvider) 
            : base(assetProvider) { }

        protected override string AssetName => nameof(KeyDataList);
    }
}
