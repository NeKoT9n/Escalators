using Assets.Escalators.Scripts.Game.Services.LoadLevel.Data;
using Cysharp.Threading.Tasks;


namespace Assets.Escalators.Scripts.Game.Services.LoadLevel
{
    public interface ILevelBuilder
    {
        public UniTask Build(LevelBuildData buildData);
    }
}
