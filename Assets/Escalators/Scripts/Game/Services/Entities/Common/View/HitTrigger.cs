using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.View
{
    public class HitTrigger : MonoBehaviour
    {
        [SerializeField] private Vector3 _hitBoxSize;
        public Vector3 HitBoxSize => _hitBoxSize; 

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, HitBoxSize);
        }
    }
}
