using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardHoverShadowScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image; 
    private Shadow shadowEffect; 

    public Color shadowColor = new Color(0, 0, 0, 0.5f); 
    public Vector2 shadowDistance = new Vector2(5, -5);  

    private Vector3 originalScale; 

    private void Start()
    {
        image = GetComponent<Image>();

        if (image == null)
        {
            Debug.LogError("Shadow can't find image!");
        }

        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (image != null && shadowEffect == null)
        {
            shadowEffect = gameObject.AddComponent<Shadow>();
            shadowEffect.effectColor = shadowColor;
            shadowEffect.effectDistance = shadowDistance;
        }

        transform.localScale = originalScale * 1.5f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (shadowEffect != null)
        {
            Destroy(shadowEffect);
        }

        transform.localScale = originalScale;
    }
}

