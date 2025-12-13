using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace Inventory
{
    public class SlotView : MonoBehaviour, IWorldView, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _description;

        public ReactiveCommand<PointerEventData> DragBegining = new();
        public ReactiveCommand<PointerEventData> DragEnded = new();
        public ReactiveCommand<PointerEventData> Droped = new();

        public GameObject GameObject => gameObject;

        public void SetIcon(Sprite icon)
            => _image.sprite = icon;


        public void SetDescription(string text)
            => _description.text = text;

        public void Clear()
        {
            _image.sprite = null;
            _description.text = string.Empty;
        }

        public void OnBeginDrag(PointerEventData eventData)
            => DragBegining.Execute(eventData);


        public void OnEndDrag(PointerEventData eventData)
            => DragEnded.Execute(eventData);

        public void OnDrop(PointerEventData eventData)
        {
            Droped.Execute(eventData);
        }
        public void OnDrag(PointerEventData eventData) { }
    }
}
