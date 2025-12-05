using Assets.CodeCore.Scripts.Game.Services.Entitieys.Model;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using UnityEngine;
using Zenject;

namespace Assets.Escalators.Scripts.Installers
{
    public class ViewInstaller : MonoInstaller
    {
        [SerializeField] private FixedJoystick _joystick;
        public override void InstallBindings()
        {
            BindInstances();
            BindPresenters();
            BindViewFactories();
        }

        private void BindInstances()
        {
            Container.BindInstance<Joystick>(_joystick).AsSingle();
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
