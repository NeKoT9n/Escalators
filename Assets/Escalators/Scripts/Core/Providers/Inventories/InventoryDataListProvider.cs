using Assets.CodeCore.Scripts.Game.Providers.Assets;
using Assets.CodeCore.Scripts.Game.Providers.Level;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data
{
    public class InventoryDataListProvider : GameDataProvider<InventoryDataList>
    {
        public InventoryDataListProvider(IAssetProvider assetProvider) 
            : base(assetProvider) { }

        protected override string AssetName => nameof(InventoryDataList);
    }
}
