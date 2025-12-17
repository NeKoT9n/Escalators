using Assets.Escalators.Scripts.Game.Services.Level.LevelParts.Arenas;

namespace Assets.Escalators.Scripts.Game.Services
{
    public interface IArenaService
    {
        void SetArena(Arena arena);
        void StartBattle();
    }
}