using Assets.Escalators.Scripts.Game.Services.Level.LevelParts.Roads;
using System.Collections.Generic;


namespace Assets.Escalators.Scripts.Game.Services.Level.Tracks.Model
{
    public class Track
    {
        public IReadOnlyList<Road> Roads => _roads;

        private readonly List<Road> _roads;

        public Track(List<Road> roads)
        {
            _roads = roads;
        }
    }
}
