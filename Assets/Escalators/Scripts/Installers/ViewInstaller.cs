using UnityEngine;
using Zenject;

namespace Assets.Escalators.Scripts.Installers
{
    public class ViewInstaller : MonoInstaller
    {
        [SerializeField] private FixedJoystick _joystick;
        public override void InstallBindings()
        {
            Container.BindInstance<Joystick>(_joystick).AsSingle();
        }

    }
}
