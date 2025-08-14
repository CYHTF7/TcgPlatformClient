using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckCardDragController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform currentTransform;
    private GameObject mainContent;
    private Vector3 currentPossition;
    private int totalChild;

    public void OnPointerDown(PointerEventData eventData)
    {
        currentPossition = currentTransform.position;
        mainContent = currentTransform.parent.gameObject;
        totalChild = mainContent.transform.childCount;
    }

    public void OnDrag(PointerEventData eventData)
    {
        currentTransform.position =
            new Vector3(currentTransform.position.x, eventData.position.y, currentTransform.position.z);

        for (int i = 0; i < totalChild; i++)
        {
            if (i != currentTransform.GetSiblingIndex())
            {
                Transform otherTransform = mainContent.transform.GetChild(i);
                int distance = (int)Vector3.Distance(currentTransform.position,
                    otherTransform.position);
                if (distance <= 10)
                {
                    Vector3 otherTransformOldPosition = otherTransform.position;
                    otherTransform.position = new Vector3(otherTransform.position.x, currentPossition.y,
                        otherTransform.position.z);
                    currentTransform.position = new Vector3(currentTransform.position.x, otherTransformOldPosition.y,
                        currentTransform.position.z);
                    currentTransform.SetSiblingIndex(otherTransform.GetSiblingIndex());
                    currentPossition = currentTransform.position;
                }
            }
        }
    }

    public async void OnPointerUp(PointerEventData eventData)
    {
        currentTransform.position = currentPossition;
        await SendOrderUpdate();
    }

    private async Task SendOrderUpdate()
    {
        var requests = new List<DeckCardOrderRequest>();

        int childCount = mainContent.transform.childCount;

        for (int i = 0; i < mainContent.transform.childCount; i++)
        {
            Transform child = mainContent.transform.GetChild(i);

            var cardController = child.GetComponent<DeckCardPrefabController>();

            if (cardController != null)
            {
                requests.Add(new DeckCardOrderRequest
                {
                    deckId = cardController._deckId,
                    cardId = cardController._cardId,
                    order = i
                });
            }
        }

        try
        {
            await ApiClient.UpdateDeckCardsOrderAsync(requests);

            DeckUIEditorController panelDeckEditor = Resources.FindObjectsOfTypeAll<DeckUIEditorController>()
                .FirstOrDefault(go => go.name == "PanelDeckEditor");

            if (panelDeckEditor != null)
            {
                panelDeckEditor.RefreshDeck(requests[0].deckId);
            }
            else 
            {
                Debug.LogError($"DeckUIEditorController was not set!");
            }

            Debug.Log("Order update request completed successfully");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to send order update: {ex.ToString()}");
            throw;
        }
    }
}