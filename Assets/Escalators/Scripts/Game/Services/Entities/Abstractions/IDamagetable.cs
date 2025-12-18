using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.Presenters;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Abstractions
{
    public interface IDamagetable
    {
        public EntityTypeId EntityType { get; }
        public void TakeDamage(int  damage);    
    }
}