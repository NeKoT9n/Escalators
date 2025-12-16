using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using UniRx;

namespace Assets.CodeCore.Scripts.Game.View
{
    public class LoseCondition : Condition
    {
        private readonly IPlayerService _playerService;

        public LoseCondition(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public override void Initialize()
        {
            _playerService.Died
                .Subscribe(_ => Complited.Execute(Unit.Default));
        }
    }
}
