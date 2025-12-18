using Assets.Escalators.Scripts.Core.Utils;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Cysharp.Threading.Tasks;
using System;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.Model
{
    public class SimpleCooldownAttacker : IAttacker, IDisposable
    {
        private float Cooldown => _entity.AttackCooldown;

        private readonly Timer _timer = new();
        private bool _canAttack = true;

        private readonly IDisposable _disposable;
        private readonly Entity _entity;

        public SimpleCooldownAttacker(Entity entity)
        {
            _entity = entity;

            _disposable = _timer.OnTimerElapsed
                .Subscribe(_ => _canAttack = true);
        }

        public async UniTask TryAttack(IDamagetable damagetable)
        {
            if (_canAttack == false)
                return;

            if(damagetable == null)
                return;

            _canAttack = false;

            await _entity.Attack();

            _timer.StartTimer(Cooldown);

        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

    }
}
