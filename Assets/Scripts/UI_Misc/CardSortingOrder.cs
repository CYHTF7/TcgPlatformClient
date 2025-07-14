using UnityEngine;
using UnityEngine.EventSystems;

public class CardSortingOrder : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Canvas canvas;

    private int originalSortingOrder;
    public int hoverSortingOrder = 1000;

    private void Start()
    {
        canvas = GetComponent<Canvas>();

        if (canvas == null)
        {
            Debug.LogError("Error! Can't find canvas!");
        }
        else
        {
            originalSortingOrder = canvas.sortingOrder;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetSortingOrder(hoverSortingOrder);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetSortingOrder(originalSortingOrder);
    }

    private void SetSortingOrder(int order)
    {
        if (canvas != null)
        {
            canvas.sortingOrder = order;
        }
    }
}


