using Assets.CodeCore.Scripts.Game.Services.Entitieys.Model;
using Assets.Escalators.Scripts.Core.UI;
using Assets.Escalators.Scripts.Game.Services.Chest.Box;
using Assets.Escalators.Scripts.Game.Services.Chest.Presenters;
using Assets.Escalators.Scripts.Game.Services.Chest.View.ChestScreen;
using Assets.Escalators.Scripts.Game.Services.Entities.EnemyLogic.Presenter;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using Assets.Escalators.Scripts.Game.Services.Game.Presenter;
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
        [SerializeField] private ChestBoxView _chest;
        [SerializeField] private ScreenView _screenView;
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
            Container.Bind<ChestBoxView>().FromInstance(_chest).AsSingle();
            Container.Bind<ScreenView>().FromInstance(_screenView).AsSingle();
        }

        private void BindPresenters()
        {
            Container.BindInterfacesTo<PlayerPresenter>().AsSingle();
            Container.BindInterfacesTo<EnemiesPresenter>().AsSingle();

            Container.BindInterfacesTo<ChestScreenPresenter>().AsSingle().NonLazy();
            Container.BindInterfacesTo<ChestPresenter>().AsSingle().NonLazy();
            Container.BindInterfacesTo<GamePresenter>().AsSingle().NonLazy();
        }

        private void BindViewFactories()
        {
            Container.Bind<EntityViewFactory>().AsSingle();
            Container.Bind<IEntityViewFactoryPlugin>().To<PlayerViewFactoryPlugin>().AsTransient();
            Container.Bind<IEntityViewFactoryPlugin>().To<EnemyViewFactoryPlugin>().AsTransient();
        }
    }
}
