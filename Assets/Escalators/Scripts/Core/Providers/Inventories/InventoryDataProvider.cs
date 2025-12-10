using Assets.CodeCore.Scripts.Game.Providers.Assets;
using Assets.CodeCore.Scripts.Game.Providers.Level;
using Inventory;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data
{
    public class InventoryDataProvider : GameDataProvider<InventoryData>
    {
        public InventoryDataProvider(IAssetProvider assetProvider) 
            : base(assetProvider) { }

        protected override string AssetName => nameof(InventoryData);
    }
}
