using Assets.Escalators.Scripts.Game.Services.Entities.Common;
using Cysharp.Threading.Tasks;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Abstractions
{
    public interface IAttacker
    {
        public UniTask<bool> Attack(Entity model);
    }
}
