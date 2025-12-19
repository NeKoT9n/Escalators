using UniRx;
using UnityEngine;

namespace Inventory
{
    public interface IChestService
    {
        public IReactiveProperty<Sprite> Icon { get; }
        public IReactiveCommand<int> KeyAdded { get; }
        public IReactiveCommand<int> KeyRemoved { get; }
        public IReactiveCommand<Unit> Opened { get; }
        public IReactiveCommand<Unit> ShowUI { get; }
    }
}
