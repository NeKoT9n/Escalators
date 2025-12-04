using Assets.Escalators.Scripts.Game.Services.Entities.Common;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Abstractions
{
    public interface IAttacker
    {
        public void Tick(Entity model, float deltaTime);
    }
}
