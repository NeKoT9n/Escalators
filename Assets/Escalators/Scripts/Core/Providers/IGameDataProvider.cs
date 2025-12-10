using Assets.CodeCore.Scripts.Game.Providers;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data
{
    public interface IGameDataProvider<TData> where TData : class, IGameData
    {
        public TData Data { get; }
    }
}
