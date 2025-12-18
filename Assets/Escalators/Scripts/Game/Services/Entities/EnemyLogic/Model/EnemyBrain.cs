using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;

namespace Assets.Escalators.Scripts.Game.Services.Entities.EnemyLogic.Model
{
    public class EnemyBrain : Brain
    {
        private readonly EnemyStateMachine _enemyStateMachine;

        public EnemyBrain(EnemyStateMachine enemyStateMachine)
        {
            _enemyStateMachine = enemyStateMachine;
            _enemyStateMachine.TrySwitchState<EnemyIdleState>();
        }

        public override void Update()
        {
            _enemyStateMachine?.Update();
            
        }
    }
}
