using Assets.CodeCore.Scripts.Game.Infostracture.Factories;
using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine;
using Assets.CodeCore.Scripts.Game.Providers.Assets;
using Assets.CodeCore.Scripts.Game.Providers.Entities;
using Assets.CodeCore.Scripts.Game.Providers.Level;
using Assets.CodeCore.Scripts.Game.Services;
using Assets.CodeCore.Scripts.Game.Services.Entitieys.Factory.Model;
using Assets.CodeCore.Scripts.Game.View;
using Assets.Escalators.Scripts.Game.Services.Entities.Factory.Model.Brains.Plugins;
using Assets.Escalators.Scripts.Game.Services.Level.LevelParts.Roads;
using Assets.Escalators.Scripts.Game.Services.Obstacles.Spawner;
using Zenject;

namespace Assets.Escalators.Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameStates();
            BindFactories();
            BindProviders();
            BindConditions();
        }

        private void BindConditions()
        {
            Container.Bind<WinCondition>().AsSingle();
            Container.Bind<LoseCondition>().AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<WorldFactory>().AsSingle();
            Container.Bind<GameStateFactory>().AsSingle();
       
            Container.Bind<EntityFactory>().AsSingle();
            Container.Bind<IEntityFactoryPlugin>().To<PlayerFactoryPlugin>().AsTransient();

            Container.Bind<IBrainFactory>().To<BrainFactory>().AsSingle();
            Container.Bind<IBrainFactoryPlugin>().To<PlayerBrainFactoryPlugin>().AsTransient();


            Container.Bind<IObstacleSpawner>().To<ObstacleSpawner>().AsTransient(); 
            Container.Bind<ObstacleFactory>().AsSingle(); 
            Container.BindFactory<Road, RoadSpawner, RoadSpawnerFactory>().AsTransient();
            
        }

        private void BindProviders()
        {
            Container.BindInterfacesTo<AddressablesAssetProvider>().AsSingle();
            Container.BindInterfacesTo<LevelDataProvider>().AsSingle();
            Container.BindInterfacesTo<EntityDataContainer>().AsSingle();
            Container.BindInterfacesAndSelfTo<ObstacleDataProvider>().AsSingle();
        }

        private void BindGameStates()
        {
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        }
    }
}
