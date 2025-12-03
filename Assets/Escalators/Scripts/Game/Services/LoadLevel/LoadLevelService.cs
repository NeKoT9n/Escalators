using Cysharp.Threading.Tasks;

namespace Assets.CodeCore.Scripts.Game.Services
{
    public class LoadLevelService : ILoadLevelService
    {

        public LoadLevelService()
        {

        }

        public UniTask LoadLevel(LevelData levelData)
        {
            return UniTask.CompletedTask;   
        }
    }
}
