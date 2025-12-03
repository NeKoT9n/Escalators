using Assets.CodeCore.Scripts.Game.Services;
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

        }
       
    }
}
