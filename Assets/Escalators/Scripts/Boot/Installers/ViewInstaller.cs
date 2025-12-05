using Assets.CodeCore.Scripts.Game.Services.Entitieys.Model;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Assets.Escalators.Scripts.Installers
{
    public class ViewInstaller : MonoInstaller
    {
        [SerializeField] private FixedJoystick _joystick;
        [SerializeField] private CinemachineCamera _camera;
        public override void InstallBindings()
        {
            BindInstances();
            BindPresenters();
            BindViewFactories();
        }

        private void BindInstances()
        {
            Container.Bind<Joystick>().FromInstance(_joystick).AsSingle();
            Container.Bind<CinemachineCamera>().FromInstance(_camera).AsSingle();
        }

        private void BindPresenters()
        {
            Container.BindInterfacesTo<PlayerPresenter>().AsSingle();
        }

        private void BindViewFactories()
        {
            Container.Bind<EntityViewFactory>().AsSingle();
            Container.Bind<IEntityViewFactoryPlugin>().To<PlayerViewFactoryPlugin>().AsTransient();
        }
    }
}
