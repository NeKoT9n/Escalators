using Assets.CodeCore.Scripts.Game.Infostracture;
using System;
using UniRx;

namespace Assets.CodeCore.Scripts.Game.View
{
    public abstract class Condition : IInitializable
    {
        public ReactiveCommand<Unit> Complited { get; private set; } = new();

        public abstract void Initialize();

    }


}
