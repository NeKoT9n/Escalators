using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model
{
    public class EmptyAttacker : IAttacker
    {
        public bool TryAttack(Entity entity, IDamagetable damagetable)
        {
            return false;
        }
    }
}
