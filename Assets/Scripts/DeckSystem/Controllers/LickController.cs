using UnityEngine;


public class ListController : MonoBehaviour
{
    [SerializeField] private int maxVisibleItems = 10;

    private int currentStartIndex = 0;
    private int lastKnownChildCount = 0;

    private int TotalItems => transform.childCount;

    private void Start()
    {
        lastKnownChildCount = TotalItems;
        UpdateList();
    }

    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f) ScrollUp();
        else if (scroll < 0f) ScrollDown();
    }

    private void OnTransformChildrenChanged()
    {
        UpdateList();
    }

    public void UpdateList()
    {
        if (currentStartIndex > TotalItems - maxVisibleItems)
        {
            currentStartIndex = Mathf.Max(0, TotalItems - maxVisibleItems);
        }

        ShowWindow();
    }

    public void ShowWindow()
    {
        int total = TotalItems;
        int endIndex = Mathf.Min(currentStartIndex + maxVisibleItems, total);

        for (int i = 0; i < total; i++)
        {
            bool isActive = i >= currentStartIndex && i < endIndex;
            transform.GetChild(i).gameObject.SetActive(isActive);
        }
    }

    public void ScrollUp()
    {
        currentStartIndex = Mathf.Max(0, currentStartIndex - 1);
        ShowWindow();
    }

    public void ScrollDown()
    {
        currentStartIndex = Mathf.Min(TotalItems - maxVisibleItems, currentStartIndex + 1);
        if (currentStartIndex < 0) currentStartIndex = 0;
        ShowWindow();
    }
}


