using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Providers.Assets;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;
using Cysharp.Threading.Tasks;

namespace Assets.CodeCore.Scripts.Game.Providers.Level
{
    public abstract class GameDataProvider<TData> :
        IGameDataProvider<TData>,
        IAsyncInitializable
        where TData : class, IGameData
    {
        public TData Data => _data;

        private IAssetProvider _assetProvider;

        private TData _data;
        protected abstract string AssetName { get; }

        public GameDataProvider(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public virtual async UniTask Initialize()
        {
            _data = await _assetProvider.Load<TData>(AssetName);
        }
    }
}
