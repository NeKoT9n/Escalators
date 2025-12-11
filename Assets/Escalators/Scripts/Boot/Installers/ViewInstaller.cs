using Assets.CodeCore.Scripts.Game.Services.Entitieys.Model;
using Assets.Escalators.Scripts.Game.Services.Chest.Presenters;
using Assets.Escalators.Scripts.Game.Services.Chest.View.ChestScreen;
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
        [SerializeField] private ChestScreenView _chestScreen;
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
            Container.Bind<ChestScreenView>().FromInstance(_chestScreen).AsSingle();
        }

        private void BindPresenters()
        {
            Container.BindInterfacesTo<PlayerPresenter>().AsSingle();

            Container
                .BindInterfacesTo<ChestScreenPresenter>()
                .AsSingle()
                .NonLazy();
        }

        private void BindViewFactories()
        {
            Container.Bind<EntityViewFactory>().AsSingle();
            Container.Bind<IEntityViewFactoryPlugin>().To<PlayerViewFactoryPlugin>().AsTransient();
        }
    }
}
