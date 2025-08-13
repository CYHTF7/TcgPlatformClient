using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class CardSortingOrderExtended : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IBeginDragHandler,
    IEndDragHandler
{
    private Canvas _canvas;
    private int _originalSortingOrder;

    [Header("Sorting Orders")]
    [SerializeField] private int _hoverSortingOrder = 1000;
    [SerializeField] private int _dragSortingOrder = 10000;

    [Header("Visual Settings")]
    [SerializeField] private float _dragAlpha = 0.75f;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _originalSortingOrder = _canvas.sortingOrder;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!IsDragging)
            SetSortingOrder(_hoverSortingOrder);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!IsDragging)
            SetSortingOrder(_originalSortingOrder);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        IsDragging = true;
        _canvasGroup.alpha = _dragAlpha;
        _canvasGroup.blocksRaycasts = false;
        SetSortingOrder(_dragSortingOrder);
    }

    public void OnDrag(PointerEventData eventData) { }

    public void OnEndDrag(PointerEventData eventData)
    {
        IsDragging = false;
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        SetSortingOrder(_originalSortingOrder);
    }

    private bool IsDragging { get; set; }

    private void SetSortingOrder(int order)
    {
        _canvas.sortingOrder = order;
    }
}