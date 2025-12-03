using Assets.CodeCore.Scripts.Game.Infostracture;
using System;
using UniRx;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture
{
    public class InputService : IInputService, IInitializable, IDisposable
    {

        private readonly CompositeDisposable _disposables = new();
        public void Initialize()
        {        
            
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
