using Assets.Escalators.Scripts.Game.Services.Obstacles.Model;
using UnityEngine;

namespace Assets.Escalators.Scripts.Core.View
{
    public class ObstacleKillZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.TryGetComponent(out ObstacleView obstacle))
            {
                obstacle.OnKillZoneEnter();
            }
        }
    }
}
