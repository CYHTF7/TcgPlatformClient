using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoosterBuyText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("UI References")]
    public TextMeshProUGUI buyText;

    private void Start()
    {
        if (buyText != null)
        {
            buyText.gameObject.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buyText != null)
        {
            buyText.gameObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buyText != null)
        {
            buyText.gameObject.SetActive(false);
        }
    }
}

