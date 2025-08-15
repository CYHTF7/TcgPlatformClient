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

        ListController listController = Resources.FindObjectsOfTypeAll<ListController>()
                .FirstOrDefault(go => go.name == "DeckCardList");

    }

    public void OnDrag(PointerEventData eventData)
    {
        ListController listController = Resources.FindObjectsOfTypeAll<ListController>()
                .FirstOrDefault(go => go.name == "DeckCardList");

        int maxVisibleItems = listController.maxVisibleItems;
        int currentStartIndex = listController.currentStartIndex;

        int firstVisibleIndex = currentStartIndex;
        int lastVisibleIndex = Mathf.Min(currentStartIndex + maxVisibleItems - 1, totalChild - 1);

        float topY = mainContent.transform.GetChild(firstVisibleIndex).position.y;
        float bottomY = mainContent.transform.GetChild(lastVisibleIndex).position.y;

        float minDragY = Mathf.Min(topY, bottomY);
        float maxDragY = Mathf.Max(topY, bottomY);

        float newY = Mathf.Clamp(eventData.position.y, minDragY, maxDragY);
        currentTransform.position = new Vector3(currentTransform.position.x, newY, currentTransform.position.z);

        for (int i = 0; i < totalChild; i++)
        {
            if (i != currentTransform.GetSiblingIndex())
            {
                Transform otherTransform = mainContent.transform.GetChild(i);
                float distance = Vector3.Distance(currentTransform.position, otherTransform.position);
                if (distance <= 10)
                {
                    Vector3 otherTransformOldPosition = otherTransform.position;
                    otherTransform.position = new Vector3(otherTransform.position.x, currentPossition.y, otherTransform.position.z);
                    currentTransform.position = new Vector3(currentTransform.position.x, otherTransformOldPosition.y, currentTransform.position.z);

                    currentTransform.SetSiblingIndex(otherTransform.GetSiblingIndex());
                    currentPossition = currentTransform.position;

                    listController.UpdateList();
                    break;
                }
            }
        }
    }

    public async void OnPointerUp(PointerEventData eventData)
    {
        currentTransform.position = currentPossition;

        ListController listController = Resources.FindObjectsOfTypeAll<ListController>()
        .FirstOrDefault(go => go.name == "DeckCardList");

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
