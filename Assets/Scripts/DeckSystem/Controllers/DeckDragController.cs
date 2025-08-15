using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeckDragController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform currentTransform;
    private GameObject mainContent;
    private Vector3 currentPossition;
    private int totalChild;
    private float minY, maxY;

    public void OnPointerDown(PointerEventData eventData)
    {
        currentPossition = currentTransform.position;
        mainContent = currentTransform.parent.gameObject;
        totalChild = mainContent.transform.childCount;

        CalculateActiveBounds();
    }

    private void CalculateActiveBounds()
    {
        bool firstActiveFound = false;

        foreach (Transform child in mainContent.transform)
        {
            if (child.gameObject.activeSelf)
            {
                if (!firstActiveFound)
                {
                    maxY = child.position.y;
                    firstActiveFound = true;
                }
                minY = child.position.y;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Button button = GetComponent<Button>();

        if (button != null)
        {
            button.interactable = false;
        }

        float newY = eventData.position.y;

        newY = Mathf.Clamp(newY, minY, maxY);

        currentTransform.position = new Vector3(currentTransform.position.x, newY, currentTransform.position.z);

        for (int i = 0; i < totalChild; i++)
        {
            if (i != currentTransform.GetSiblingIndex())
            {
                Transform otherTransform = mainContent.transform.GetChild(i);
                if (!otherTransform.gameObject.activeSelf) continue;

                int distance = (int)Vector3.Distance(currentTransform.position, otherTransform.position);
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

        Button button = GetComponent<Button>();

        if (button != null)
        {
            button.interactable = true;
        }
    }

    private async Task SendOrderUpdate()
    {
        var requests = new List<DeckOrderRequest>();

        int childCount = mainContent.transform.childCount;

        for (int i = 0; i < mainContent.transform.childCount; i++)
        {
            Transform child = mainContent.transform.GetChild(i);

            var cardController = child.GetComponent<DeckPrefabController>();

            if (cardController != null)
            {
                requests.Add(new DeckOrderRequest
                {
                    deckId = cardController._deckData.DeckId,
                    order = i
                });
            }
        }

        try
        {
            await ApiClient.UpdateDecksOrderAsync(requests);

            DeckListController deckList = Resources.FindObjectsOfTypeAll<DeckListController>()
                .FirstOrDefault(go => go.name == "PanelDeckList");

            if (deckList != null)
            {
                await deckList.UpdateDeckListAsync();
            }
            else
            {
                Debug.LogError($"DeckListController was not set!");
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

