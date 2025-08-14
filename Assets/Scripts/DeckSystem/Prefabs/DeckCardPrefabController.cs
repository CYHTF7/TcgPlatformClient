using UnityEngine;
using Cards;
using System.Linq;
using TMPro;
using UnityEngine.EventSystems;
using System;
using System.Threading.Tasks;


public class DeckCardPrefabController : MonoBehaviour, IPointerClickHandler
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _deckCardNameText;

    private int _cardId;
    private int _deckId;

    public static event Action<int> OnCardChanged;

    private void Awake()
    {
        if (_deckCardNameText == null)
        {
            Debug.LogError("CardDeckPrefabController: Invalid references!");
        }
    }

    public void SetCardDeckData(int DeckId,int CardId, int Quantity)
    {
        _deckId = DeckId;
        _cardId = CardId;

        if (_deckCardNameText == null)
        {
            return;
        }

        var card = CardDataStorage.Instance.combinedCardList
            .OfType<Card>() 
            .FirstOrDefault(c => c.id == CardId);

        if (card == null)
        {
            Debug.LogWarning($"Card with ID {card.CardId} not found!");
        }

        string cardNameText = card.cardName;

        _deckCardNameText.text = $"x{Quantity} {cardNameText}";
    }

    public async void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            try 
            {
                var request = new DeckCardRemoveRequest
                {
                    deckId = _deckId,
                    cardId = _cardId,
                    quantity = 1
                };

                await ApiClient.RemoveCardFromDeckAsync(request);

                var editor = FindObjectOfType<DeckUIEditorController>();
                if (editor != null)
                {
                    editor.RefreshDeck(_deckId);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Add card failed: {ex.Message}");
            }
        }
    }
}
