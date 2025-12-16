using Assets.Escalators.Scripts.Core.Utils;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using System;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model
{
    public class SimpleCooldownAttacker : IAttacker, IDisposable
    {
        private readonly float _cooldown;

        private readonly Timer _timer = new();
        private bool _canAttack = true;

        private readonly IDisposable _disposable;
        public SimpleCooldownAttacker(float cooldown)
        {
            _cooldown = cooldown;

            _disposable = _timer.OnTimerElapsed
                .Subscribe(_ => _canAttack = true);
        }

        public bool TryAttack(Entity entity, IDamagetable damagetable)
        {
            if(_canAttack == false)
                return false;

            if(damagetable == null)
                return false;

            _canAttack = false;

            entity.Attack.Execute();
            damagetable.TakeDamage(20);

            _timer.StartTimer(_cooldown);

            return true;
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

    }
}
