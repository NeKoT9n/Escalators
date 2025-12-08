using Assets.CodeCore.Scripts.Game.Services;
using System.Collections.Generic;
using System.Threading;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Level.Tracks.Model
{
    public class TrackSpawner 
    {
        private List<RoadSpawner> _roadSpawners;
        private CancellationTokenSource _cancellationToken;

        public TrackSpawner(List<RoadSpawner> spawners)
        {
            _roadSpawners = spawners;
        }

        public void StartSpawn()
        {
            StopSpawn();

            _cancellationToken = new CancellationTokenSource();

            foreach(var roadSpawner in _roadSpawners)
            {
                roadSpawner.StartSpawn(_cancellationToken.Token);
            }
        }

        public void StopSpawn()
        {
            _cancellationToken?.Cancel();
        }

    }

    public interface ITrackService
    {
        public IReactiveCollection<Track> Tracks { get; }
        public void AddTrack(Track track);
    }
}
