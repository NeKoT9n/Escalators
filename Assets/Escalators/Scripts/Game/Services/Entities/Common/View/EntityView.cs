using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Common.View
{
    public class EntityView : MonoBehaviour, IWorldView
    {
        public GameObject GameObject => gameObject;

        public void SetPosition(Vector3 position)
            => transform.position = position;

        public void SetRotation(Quaternion rotation)
            => transform.rotation = rotation;

    }
}
