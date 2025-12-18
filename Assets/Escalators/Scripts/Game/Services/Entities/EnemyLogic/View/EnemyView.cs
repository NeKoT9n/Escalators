using Assets.Escalators.Scripts.Game.Services.Entities.Common.View;
using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;

namespace Assets.Escalators.Scripts.Game.Services.Entities.EnemyLogic.View
{
    public class EnemyView : EntityView
    {
        public override EntityTypeId EntityType => EntityTypeId.Enemy;
    }
}
