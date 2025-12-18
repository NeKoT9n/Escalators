using Assets.CodeCore.Scripts.Game.Startup.GameStates;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.TargetFinder;
using Assets.Escalators.Scripts.Game.Services.Entities.EnemyLogic.Model;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Model;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using System.Collections.Generic;
using static Assets.Escalators.Scripts.Game.Services.Entities.EnemyLogic.Model.EnemyIdleState;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Factory.Model.Brains.Plugins
{
    public class EnemyBrainFactoryPlugin : IBrainFactoryPlugin
    {
        public EntityTypeId Key => EntityTypeId.Enemy;

        public Brain Create(Entity entity)
        {
            var targetFinder = new TargetFinder(entity);
            IMover mover = new TargetMover(entity, targetFinder);
            IAttacker attacker = new SimpleCooldownAttacker(entity);

            EnemyStateMachine enemyStateMachine = new();

            EnemyIdleState idle = new(targetFinder, enemyStateMachine);
            EnemyChaseState chase = new(targetFinder, mover, entity, enemyStateMachine);
            EnemyAttackState attack = new(attacker, mover, targetFinder, enemyStateMachine);

            enemyStateMachine.Initialize(new List<IState>()
            {
                idle,
                chase,
                attack
            });

            return new EnemyBrain(enemyStateMachine);
        }
    }
}
