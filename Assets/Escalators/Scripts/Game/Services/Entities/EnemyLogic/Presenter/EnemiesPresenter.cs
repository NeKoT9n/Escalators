using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.CodeCore.Scripts.Game.Services.Entitieys.Model;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Presenters;
using System;
using System.Collections.Generic;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.EnemyLogic.Presenter
{
    public class EnemiesPresenter : IInitializable, IDisposable
    {
        private readonly IEnemyService _enemyService;
        private readonly EntityViewFactory _entityViewFactory;
        private readonly List<EntityPresenter> _entities = new();

        private CompositeDisposable _disposables = new();
        public EnemiesPresenter(IEnemyService enemyService, EntityViewFactory entityViewFactory)
        {
            _enemyService = enemyService;
            _entityViewFactory = entityViewFactory;
        }

        public void Initialize()
        {
            _enemyService.Enemies
                .ObserveAdd()
                .Subscribe(eventData => SpawnEnemy(eventData.Value))
                .AddTo(_disposables);
        }

        private async void SpawnEnemy(Enemy enemy)
        {
            var view = await _entityViewFactory.Spawn(enemy);

            EntityPresenter presenter = new(enemy, view);
            presenter.Initialize();

            _entities.Add(presenter);   
        }

        public void Dispose()
        {
            foreach(var entity in _entities)
                entity.Dispose();

            _disposables.Dispose();
        }

    }
}
