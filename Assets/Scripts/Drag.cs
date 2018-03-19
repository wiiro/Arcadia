using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

    public Transform currentParent = null;
    public bool isDraggable = true;
    public int simbolo;

    public void OnDrag(PointerEventData eventData)
    {
        if (isDraggable) { 
        this.transform.position = eventData.position;
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        if (isDraggable)
        {
            currentParent = this.transform.parent;
            this.transform.SetParent(this.transform.parent.parent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
            this.transform.SetParent(currentParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    
}
