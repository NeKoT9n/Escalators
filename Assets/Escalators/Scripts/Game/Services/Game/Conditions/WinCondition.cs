using Inventory;
using System;
using UniRx;

namespace Assets.CodeCore.Scripts.Game.View
{
    public class WinCondition : Condition, IDisposable
    {
        private readonly IChestService _chestService;
        private IDisposable _disposable;

        public WinCondition(IChestService chestService)
        {
            _chestService = chestService;
        }

        public override void Initialize()
        {
            _disposable = _chestService.Opened
                .Subscribe(_ => Complited.Execute(Unit.Default));
        }
        public void Dispose()
        {
            _disposable.Dispose();
        }
    }


}
