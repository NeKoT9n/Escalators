using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Services;
using Assets.Escalators.Scripts.Core.Services.Update;
using Assets.Escalators.Scripts.Game.Services.Camera;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory;
using Assets.Escalators.Scripts.Game.Services.Chest.Presenters;
using Assets.Escalators.Scripts.Game.Services.DragAndDrop;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.LoadLevel;
using Assets.Escalators.Scripts.Game.Services.Obstacles.Model;
using Inventory;
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
                .BindInterfacesTo<InputService>()
                .AsSingle();   

            Container
                .BindInterfacesTo<PlayerService>()     
                .AsSingle();
            
            Container
                .BindInterfacesTo<TargetZCameraService>()     
                .AsSingle();

            Container
                .Bind<IUpdateService>()
                .To<UpdateService>().AsSingle();

            Container
                .Bind<ILevelBuilder>()
                .To<LevelBuilder>().AsSingle();

            Container
                .Bind<IObstacleService>()
                .To<ObstacleService>()
                .AsSingle();


            Container
                .BindInterfacesTo<InventoryRandomKeyFiller>()
                .AsSingle();
            
            Container
                .BindInterfacesTo<DragService>()
                .AsSingle();
            
            Container
                .Bind<InventoryDragHandler>()
                .AsSingle();

            Container
                .BindInterfacesTo<InventoryService>()
                .AsSingle();
        }


    }
}
