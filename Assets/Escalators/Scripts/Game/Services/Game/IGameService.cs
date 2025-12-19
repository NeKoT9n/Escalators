using UniRx;

namespace Assets.CodeCore.Scripts.Game.Services.Game
{
    public interface IGameService
    {
        public IReactiveCommand<Unit> Win { get; }
        public IReactiveCommand<Unit> Lose { get; }
        public void ShowLose();
        public void ShowWin();
        public void Restart();
    }
}