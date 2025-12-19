using Assets.CodeCore.Scripts.Game.Helpers;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.CodeCore.Scripts.Game.Services.SceneLoad
{
    public class SceneLoadService
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;

        private string _currentSceneName;

        public SceneLoadService(
            ISceneLoader sceneLoader,
            LoadingCurtain loadingCurtain)
        {
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
        }

        public async UniTask LoadGameScene(string level)
        {
            _loadingCurtain.Show();

            _currentSceneName = level;
            await _sceneLoader.LoadScene(Constants.SceneNames.GAME);
            await _sceneLoader.LoadScene(level, LoadSceneMode.Additive);
        }

        public async UniTask RestartLevel()
        {
            await _sceneLoader.UnloadAllScenes();
            await LoadGameScene(_currentSceneName);
        }

        public async UniTask LoadBootScene()
        {
            _loadingCurtain.Show();
            await _sceneLoader.LoadScene(Constants.SceneNames.BOOT);

        }

        public async UniTask LoadMainMenuScene()
        {
            _loadingCurtain.Show();

            await _sceneLoader.LoadScene(Constants.SceneNames.MAIN_MENU);

            _loadingCurtain.Hide();
        }



    }
}
