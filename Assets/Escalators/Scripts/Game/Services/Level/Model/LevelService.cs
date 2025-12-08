using Assets.Escalators.Scripts.Game.Services.Level.Tracks.Model;
using Assets.Escalators.Scripts.Game.Services.LoadLevel;
using Assets.Escalators.Scripts.Game.Services.LoadLevel.Data;

namespace Assets.Escalators.Scripts.Game.Services.Level.Model
{
    public class LevelService : ILevelSerice
    {
        private readonly ITrackService _trackService;
        private readonly ILevelBuilder _levelBuilder;
        private Level _level;

        public LevelService(ITrackService trackService, ILevelBuilder levelBuilder)
        {
            _trackService = trackService;
            _levelBuilder = levelBuilder;
        }

        public void SetLevel(Level level)
        {
            _level = level;
        }

        public void SpawnLevel(LevelBuildData buildData)
        {
            var data = _levelBuilder.Build(buildData);
        }
    }

    public interface ILevelSerice
    {
        
    }
}
