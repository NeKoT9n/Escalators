using Assets.CodeCore.Scripts.Game.Providers.Assets;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

namespace Assets.CodeCore.Scripts.Game.Providers.Entities
{
    public interface IGameDataProvider<TData> where TData : IGameData
    {

        public UniTask<List<TData>> Initialize(IAssetProvider assetProvider);
    }
}
