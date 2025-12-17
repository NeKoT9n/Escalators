using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic.View;
using UniRx;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Level.LevelParts.Arenas
{
    public class ArenaTrigger : MonoBehaviour
    {
        public ReactiveCommand<PlayerView> Triggered { get; private set; } = new();

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.TryGetComponent(out PlayerView playerView))
            {
                Triggered.Execute(playerView);
            }
        }
    }
}
