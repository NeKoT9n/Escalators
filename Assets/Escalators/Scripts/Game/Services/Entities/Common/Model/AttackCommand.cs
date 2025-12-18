using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common
{
    public class AttackCommand : UniTaskCommand
    {
        public float Damage;
        public AttackCommand(float damage) : base()
        {
            Damage = damage;
        }
    }
}