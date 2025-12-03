using UnityEngine;

namespace Assets.CodeCore.Scripts.Game.Helpers
{
    public class SpawnPointMarker : MonoBehaviour
    {
        public Vector2 Position => transform.position;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.2f);
        }
    }
}
