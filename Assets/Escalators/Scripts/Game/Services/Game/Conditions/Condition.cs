using Assets.CodeCore.Scripts.Game.Infostracture;
using System;
using UniRx;

namespace Assets.CodeCore.Scripts.Game.View
{
    public abstract class Condition : IInitializable, IDisposable
    {
        protected readonly Subject<Unit> _complited = new();
        protected readonly CompositeDisposable _disposables = new ();

        public IObservable<Unit> Complited => _complited;

        public abstract void Initialize();

        public virtual void Dispose()
        {
            _disposables?.Dispose();    
        }
    }


}
