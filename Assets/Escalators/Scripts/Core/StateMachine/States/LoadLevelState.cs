using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine;
using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine.States.Interfaces;
using Assets.CodeCore.Scripts.Game.Providers.Level;
using Assets.CodeCore.Scripts.Game.Services;
using Assets.CodeCore.Scripts.Game.Services.SceneLoad;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data;

namespace Assets.CodeCore.Scripts.Game.Startup.GameStates.States
{
    public class LoadLevelState : IEnterableState, IExitableState
    {

        private readonly ILoadLevelService _loadLevelService;
        private readonly IGameDataProvider<LevelData> _levelDataProvider;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly LoadingCurtain _loadingCurtain;

        public LoadLevelState(
            ILoadLevelService loadLevelService,
            IGameDataProvider<LevelData> levelDataProvider,
            IStateSwitcher stateSwitcher,
            LoadingCurtain loadingCurtain)
        {
            _loadLevelService = loadLevelService;
            _levelDataProvider = levelDataProvider;
            _stateSwitcher = stateSwitcher;
            _loadingCurtain = loadingCurtain;
        }
        public async void Enter()
        {
            LevelData levelData = _levelDataProvider.Data;
            await _loadLevelService.LoadLevel(levelData);

            _stateSwitcher.TrySwitchState<CrossingRoadsState>();

        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }
    }
}
