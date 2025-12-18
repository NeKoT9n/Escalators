using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Cysharp.Threading.Tasks;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model
{
    public class EmptyAttacker : IAttacker
    {
        public UniTask TryAttack(IDamagetable damagetable)
        {
            return UniTask.CompletedTask;
        }
    }
}
