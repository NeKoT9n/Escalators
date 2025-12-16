using Cysharp.Threading.Tasks;
using System.Threading;
using System;
using UnityEngine;
using UniRx;

namespace Assets.Escalators.Scripts.Core.Utils
{
    public class Timer
    {
        public IObservable<Unit> OnTimerElapsed => _timerElapsed;

        private Subject<Unit> _timerElapsed = new();
        private CancellationTokenSource _cancellationToken;

        public void StartTimer(float seconds)
        {
            _cancellationToken?.Cancel();
            _cancellationToken?.Dispose();

            _cancellationToken = new();

            UpdateTimer(seconds, _cancellationToken.Token)
                .ContinueWith(() => _timerElapsed.OnNext(Unit.Default))
                .Forget();
        }

        private async UniTask UpdateTimer(float time ,CancellationToken cancellationToken)
        {
            try
            {
                await UniTask.WaitForSeconds(time, cancellationToken: cancellationToken);
            }
            catch (OperationCanceledException)
            {
                Debug.LogWarning("Timer canceled");
            }
            finally
            {
                _cancellationToken?.Dispose();
            }

        }
    }
}
