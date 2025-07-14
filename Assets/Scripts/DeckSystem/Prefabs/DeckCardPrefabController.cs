using UnityEngine;
using Cards;
using System.Linq;
using TMPro;


public class DeckCardPrefabController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _deckCardNameText;

    private void Awake()
    {
        if (_deckCardNameText == null)
        {
            Debug.LogError("CardDeckPrefabController: Invalid references!");
        }
    }

    public void SetCardDeckData(int CardId, int Quantity)
    {
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
}
