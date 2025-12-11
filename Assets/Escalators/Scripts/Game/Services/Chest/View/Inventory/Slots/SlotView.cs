using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace Inventory
{
    public class SlotView : MonoBehaviour, IWorldView, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _description;

        public ReactiveCommand<PointerEventData> DragBegining = new();
        public ReactiveCommand<PointerEventData> DragEnded = new();
        public ReactiveCommand DragHandled = new();

        public GameObject GameObject => gameObject;
        public bool IsEmpty => _image.sprite == null;

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

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("Drag Started");
            DragBegining.Execute(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("Drag Ended");
            DragEnded.Execute(eventData);
        }

        public void OnDragHandled()
        {
            DragHandled.Execute();
        }

        public void OnDrag(PointerEventData eventData) { }
    }
}
