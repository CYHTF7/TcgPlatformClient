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

    public int _cardId { get; private set; }
    public int _deckId { get; private set; }
    public int _quantity { get; private set; }
    public int _order { get; private set; }

    public static event Action<int> OnCardChanged;

    private void Awake()
    {
        if (_deckCardNameText == null)
        {
            Debug.LogError("CardDeckPrefabController: Invalid references!");
        }
    }

    public void SetCardDeckData(int DeckId,int CardId, int Quantity, int Order)
    {
        _deckId = DeckId;
        _cardId = CardId;
        _quantity = Quantity;
        _order = Order;

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

        switch (card.rarity)
        {
            case Rarity.Common:
                _deckCardNameText.color = Color.white;
                break;
            case Rarity.Uncommon:
                _deckCardNameText.color = new Color(0.1f, 0.8f, 0.2f);
                break;
            case Rarity.Rare:
                _deckCardNameText.color = new Color(0.1f, 0.2f, 0.8f);
                break;
            case Rarity.Epic:
                _deckCardNameText.color = new Color(0.6f, 0.2f, 0.8f);
                break;
            case Rarity.RareGold:
                _deckCardNameText.color = new Color(1f, 0.5f, 0f);
                break;
            default:
                _deckCardNameText.color = Color.white;
                break;
        }
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
