using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Obstacles.Spawner
{
    public class ObstacleSpawnMarker : MonoBehaviour
    {
        [SerializeField] private float _obstacleSpeedMin;
        [SerializeField] private float _obstacleSpeedMax;

        public Vector3 Position => transform.position;
        public Quaternion Rotation => Quaternion.Euler(transform.forward);
        public float MinSpeed => _obstacleSpeedMin;
        public float MaxSpeed => _obstacleSpeedMax;
    }
}
