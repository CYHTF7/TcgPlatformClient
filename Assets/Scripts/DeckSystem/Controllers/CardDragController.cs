using System.Linq;
using System.Windows.Forms;
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

        GameObject panel = GameObject.Find("PanelDeckList");
        bool isPanelActive = panel != null && panel.activeInHierarchy;

        if (!isPanelActive)
        {
            Canvas dropZone = GameObject.Find("DropZone")?.GetComponent<Canvas>();
            dropZone.sortingOrder = 5000;

            GameObject blockZone = Resources.FindObjectsOfTypeAll<GameObject>()
                .FirstOrDefault(go => go.name == "BlockZoneCollection");

            blockZone.SetActive(true);
        }
        else 
        {
            GameObject blockZone = Resources.FindObjectsOfTypeAll<GameObject>()
                .FirstOrDefault(go => go.name == "BlockZoneAll");

            blockZone.SetActive(true);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _rectTransform.position = _startPosition;
        transform.SetParent(_originalParent);

        GameObject panel = GameObject.Find("PanelDeckList");
        bool isPanelActive = panel != null && panel.activeInHierarchy;

        if (!isPanelActive)
        {
            Canvas dropZone = GameObject.Find("DropZone")?.GetComponent<Canvas>();
            dropZone.sortingOrder = 0;

            GameObject blockZone = Resources.FindObjectsOfTypeAll<GameObject>()
                .FirstOrDefault(go => go.name == "BlockZoneCollection");

            blockZone.SetActive(false);
        }
        else 
        {
            GameObject blockZone = Resources.FindObjectsOfTypeAll<GameObject>()
                .FirstOrDefault(go => go.name == "BlockZoneAll");

            blockZone.SetActive(false);
        }
    }
}
