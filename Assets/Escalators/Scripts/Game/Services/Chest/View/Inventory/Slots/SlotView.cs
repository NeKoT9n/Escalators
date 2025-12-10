using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace Inventory
{
    public class SlotView : MonoBehaviour, IWorldView
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _description;

        public GameObject GameObject => gameObject;

        public void SetIcon(Sprite icon)
        {
            _image.sprite = icon;
        }

        public void SetDescription(string text)
        {
            _description.text = text;
        }

        public void Clear()
        {
            _image.sprite = null;
            _description.text = string.Empty;
        }
    }
}
