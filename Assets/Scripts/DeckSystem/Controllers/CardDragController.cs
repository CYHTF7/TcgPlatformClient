using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(CanvasGroup))]
public class CardDragController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private Vector3 _startPosition;
    private Transform _originalParent;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPosition = _rectTransform.position;
        _originalParent = transform.parent;
        transform.SetParent(GetComponentInParent<Canvas>().transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.position = eventData.position;

        Canvas dropZone = GameObject.Find("DropZone").GetComponent<Canvas>();
        if (dropZone != null)

        {
            dropZone.sortingOrder = 4500;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _rectTransform.position = _startPosition;
        transform.SetParent(_originalParent);

        Canvas dropZone = GameObject.Find("DropZone").GetComponent<Canvas>();
        if (dropZone != null)

        {
            dropZone.sortingOrder = 3000;
        }
    }
}
