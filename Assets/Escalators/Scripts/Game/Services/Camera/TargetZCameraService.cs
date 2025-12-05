using Assets.CodeCore.Scripts.Game.Infostracture;
using Assets.Escalators.Scripts.Core.StateMachine.States.Interfaces;
using Assets.Escalators.Scripts.Game.Services.Entities.Abstractions;
using Unity.Cinemachine;
using UnityEngine;
using UniRx;

namespace Assets.Escalators.Scripts.Game.Services.Camera
{
    public class TargetZCameraService : ICameraService, ILateUpdatable
    {
        private readonly CinemachineCamera _camera;

        private readonly float _fixedX;
        private readonly float _fixedY;

        private Transform _target = null;
        private readonly Transform _proxyTarget;

        public TargetZCameraService(CinemachineCamera camera)
        {
            _camera = camera;

            _proxyTarget = new GameObject("[CameraProxyTarget]").transform;

            _camera.Follow = _proxyTarget;

            _fixedX = _camera.transform.position.x;
            _fixedY = _camera.transform.position.y;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
            UpdateProxyPosition(_target);
        }

        public void LateUpdate()
        {
            UpdateProxyPosition(_target);
        }

        private void UpdateProxyPosition(Transform realTarget)
        {
            if(realTarget == null)
                return;

            Vector3 newPosition = new(_fixedX, _fixedY, realTarget.position.z);
            _proxyTarget.position = newPosition;
        }

    }



    public interface ICameraService
    {
        public void SetTarget(Transform target);
    }
}
