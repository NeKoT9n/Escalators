using UnityEngine;
using UnityEngine.EventSystems;

public class PointerLogger : MonoBehaviour,
    IPointerDownHandler, IPointerUpHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler,
    IPointerEnterHandler, IPointerExitHandler
{
    void Log(string s, PointerEventData e = null)
    {
        Debug.Log($"[PointerLogger] {s} on {gameObject.name} id={e?.pointerId} pos={(e != null ? e.position.ToString() : "n/a")}");
    }

    public void OnPointerDown(PointerEventData eventData) => Log("PointerDown", eventData);
    public void OnPointerUp(PointerEventData eventData) => Log("PointerUp", eventData);
    public void OnBeginDrag(PointerEventData eventData) => Log("BeginDrag", eventData);
    public void OnDrag(PointerEventData eventData) => Log("Drag", eventData);
    public void OnEndDrag(PointerEventData eventData) => Log("EndDrag", eventData);
    public void OnPointerEnter(PointerEventData eventData) => Log("Enter", eventData);
    public void OnPointerExit(PointerEventData eventData) => Log("Exit", eventData);
}