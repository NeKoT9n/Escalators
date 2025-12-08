using Assets.Escalators.Scripts.Core.View;
using Assets.Escalators.Scripts.Game.Services.Level.LevelParts.Arenas;
using Assets.Escalators.Scripts.Game.Services.Level.Start;
using Assets.Escalators.Scripts.Game.Services.Level.Tracks.Model;
using Assets.Escalators.Scripts.Game.Services.LoadLevel.Data;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;



namespace Assets.Escalators.Scripts.Game.Services.LoadLevel
{
    public interface ILevelBuilder
    {
        public UniTask<LevelBuildedData> Build(LevelBuildData buildData);
    }

    public struct LevelBuildedData
    {
        public StartPlaceBuildedData StartPlace;
        public List<TrackBuildedData> Tracks;
        public ArenaBuildedData Arena;
    }
    
    public struct StartPlaceBuildedData
    {
        public StartPlace Model;
        public StartPlaceView View;
    }

    public struct TrackBuildedData
    {
        public Track Model;
        public List<RoadView> View;
    }

    public struct ArenaBuildedData
    {
        public Arena Model;
        public ArenaView View;
    }
}
