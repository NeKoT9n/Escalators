using Assets.CodeCore.Scripts.Game.Services.SceneLoad;
using Assets.Escalators.Scripts.Core.Services.Update;
using UnityEngine;
using Zenject;

namespace Assets.Escalators.Scripts.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;
        public override void InstallBindings()
        {
            Container.BindInstance(_loadingCurtain).AsSingle();
            Container.Bind<ISceneLoader>().To<AddressablesSceneLoader>().AsSingle();
            Container.Bind<SceneLoadService>().AsSingle();
        }
    }
}
