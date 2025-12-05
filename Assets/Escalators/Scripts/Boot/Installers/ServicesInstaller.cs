using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Services;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using System;
using Zenject;

namespace Assets.Escalators.Scripts.Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ILoadLevelService>()
                .To<LoadLevelService>()
                .AsSingle();

            Container
                .Bind<IInputService>()
                .To<InputService>()
                .AsSingle();   

            Container
                .Bind<IPlayerService>()
                .To<PlayerService>()
                .AsSingle();

        }


    }
}
