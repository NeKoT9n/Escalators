using Assets.CodeCore.Scripts.Game.Infostracture.StateMachine;
using Assets.CodeCore.Scripts.Game.Startup.GameStates;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.StateMachine.States.Transitions;
using Assets.Escalators.Scripts.Game.Services.Entities.Common.Model.TargetFinder;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;
using System.Collections.Generic;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Factory.Model.Brains.Plugins
{
    public class EnemyBrainFactoryPlugin : IBrainFactoryPlugin
    {
        private ITargetFinder _targetFinder;

        public EntityTypeId Key => EntityTypeId.Enemy;

        public Brain Create(Entity entity)
        {
            EntityStateMachine enemyStateMachine = new();

            EntityFindTargetState findTarget = CreateFindState(entity, enemyStateMachine);
            EntityMoveState move = CreateMoveState(entity, enemyStateMachine);
            EntityAttackState attack = CreateAttackState(entity, enemyStateMachine);

            TargetFindCondition targetFindCondition = new(_targetFinder);

            findTarget.AddTransition(new StateTransition(move, targetFindCondition.Finded()));
            attack.AddTransition(new StateTransition(findTarget, attack.Fineshed));

            enemyStateMachine.Initialize(new List<IState>()
            {
                move,
                findTarget,
                attack
            });

            var brain = new EntityBrain(enemyStateMachine);
            brain.Initialize();

            return brain;
        }

        private EntityMoveState CreateMoveState(Entity entity, IStateSwitcher stateSwitcher)
        {
            IMover mover = new TargetMover(_targetFinder);

            return new(entity, mover, stateSwitcher);
        }

        private EntityFindTargetState CreateFindState(Entity entity, IStateSwitcher stateSwitcher)
        {
            _targetFinder = new TargetFinder(friendlyType: Key);

            return new(stateSwitcher, _targetFinder, entity);
        }

        private EntityAttackState CreateAttackState(Entity entity, IStateSwitcher stateSwitcher)
        {
            IAttacker attacker = new SimpleCooldownAttacker(entity.AttackCooldown);

            return new(_targetFinder, attacker, entity, stateSwitcher);
        }
    }
}
