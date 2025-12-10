using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class ItemView : MonoBehaviour, IWorldView
    {
        public GameObject GameObject => gameObject;
    }
}
