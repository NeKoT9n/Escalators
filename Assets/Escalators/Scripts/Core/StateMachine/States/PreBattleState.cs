using Assets.Escalators.Scripts.Game.Services;

namespace Assets.CodeCore.Scripts.Game.Startup.GameStates.States
{
    public class PreBattleState : IEnterableState
    {
        private readonly IArenaService _arenaService;

        public PreBattleState(IArenaService arenaService)
        {
            _arenaService = arenaService;
        }

        public void Enter()
        {
            _arenaService.StartBattle();
        }
    }
}
