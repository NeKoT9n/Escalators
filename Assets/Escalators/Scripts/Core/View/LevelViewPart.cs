using UnityEngine;

namespace Assets.Escalators.Scripts.Core.View
{
    public class LevelViewPart : MonoBehaviour
    {
        [SerializeField] private Transform _anchorStart;
        [SerializeField] private Transform _anchorEnd;

        public Vector3 AnchorStart => _anchorStart.localPosition;
        public Vector3 AnchorEnd => _anchorEnd.localPosition;
    }

}
