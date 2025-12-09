using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Core.StateMachine.States.Interfaces;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace Assets.Escalators.Scripts.Core.Services.Update
{
    public class UpdateService : IUpdateService
    {
        private readonly IEnumerable<IUpdatable> _updatables;
        private readonly IEnumerable<IFixedUpdatable> _fixedUpdatables;
        private readonly IEnumerable<ILateUpdatable> _lateUpdatables;

        private CancellationTokenSource _cancellToken;

        public UpdateService(
            IEnumerable<IUpdatable> updatables,
            IEnumerable<IFixedUpdatable> fixedUpdatables,
            IEnumerable<ILateUpdatable> lateUpdatables)
        {
            _updatables = updatables;
            _fixedUpdatables = fixedUpdatables;
            _lateUpdatables = lateUpdatables;
        }

        public void Start()
        {
            _cancellToken = new();

            StartUpdateLoop(_cancellToken.Token).Forget();
            StartFixedUpdateLoop(_cancellToken.Token).Forget();
            StartLateUpdateLoop(_cancellToken.Token).Forget();
        }

        private async UniTask StartUpdateLoop(CancellationToken token)
        {

            while (token.IsCancellationRequested == false)
            {
                foreach (var updatable in _updatables)
                {
                    updatable.Update();
                }
                await UniTask.Yield(PlayerLoopTiming.Update, _cancellToken.Token);
            }
        }
            
        private async UniTask StartFixedUpdateLoop(CancellationToken token)
        {
            while (token.IsCancellationRequested == false)
            {
                foreach (var updatable in _fixedUpdatables)
                {
                    updatable.FixedUpdate();
                }
                await UniTask.Yield(PlayerLoopTiming.FixedUpdate, _cancellToken.Token);
            }
        }

        private async UniTask StartLateUpdateLoop(CancellationToken token)
        {
            while (token.IsCancellationRequested == false)
            {
                foreach (var updatable in _lateUpdatables)
                {
                    updatable.LateUpdate();
                }
                await UniTask.Yield(PlayerLoopTiming.PreLateUpdate, _cancellToken.Token);
            }
        }

        public void Stop()
        {
            _cancellToken.Cancel();
        }
    }

    public interface IUpdateService
    {
        public void Start();
        public void Stop();
    }
}
