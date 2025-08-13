using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckDropZoneController : MonoBehaviour, IDropHandler
{
    [Header("Logic References")]
    [SerializeField] private DeckUIEditorController _deckUIEditorController;

    public static event Action<int> OnCardChanged;

    public void OnDrop(PointerEventData eventData)
    {
        if (_deckUIEditorController == null || eventData.pointerDrag == null)
            return;

        var cardLoader = eventData.pointerDrag.GetComponent<CardLoader>();
        if (cardLoader != null && _deckUIEditorController.currentDeckId > 0)
        {
            AddCardToDeck(cardLoader.cardId, _deckUIEditorController.currentDeckId);
        }
    }

    private async void AddCardToDeck(int cardId, int deckId)
    {
        try
        {
            var request = new DeckCardDTO
            {
                deckId = deckId,
                cardId = cardId,
                quantity = 1
            };

            await ApiClient.AddCardToDeckAsync(request);

            var editor = FindObjectOfType<DeckUIEditorController>();
            if (editor != null)
            {
                editor.RefreshDeck(deckId);
            }

        }
        catch (Exception ex)
        {
            Debug.LogError($"Add card failed: {ex.Message}");
        }
    }
}
