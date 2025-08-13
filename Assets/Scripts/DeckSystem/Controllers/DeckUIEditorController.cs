using UnityEngine;
using TMPro;
using System;
using System.Linq;
using UnityEngine.Events;
using System.Threading.Tasks;

public class DeckUIEditorController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _deckNameText;
    [SerializeField] private Transform _deckListContent;
    [SerializeField] private GameObject _deckCardPrefab;

    [Header("Logic References")]
    [SerializeField] private DeckUIController _deckUIController;
    [SerializeField] private DeckListController _deckListController;

    [Header("Deck Data")]
    [SerializeField]
    public int currentDeckId;

    private void Awake()
    {
        if (_deckNameText == null || _deckListContent == null || _deckCardPrefab == null || _deckUIController == null)
        {
            Debug.LogError("DeckUIEditorController: Invalid references!");
            return;
        }
    }

    public void BackButton() 
    {
        _deckUIController.ShowDeckListPanel();
    }

    public void DisplayDeckContent(Deck deck)
    {
        if (deck == null)
        {
            Debug.LogError("DeckUIEditorController: deck is null!");
            return;
        }

        currentDeckId = deck.DeckId;

        Debug.Log($"Was set currentDeckId: {currentDeckId}");

        _deckUIController.ShowDeckEditorPanel();

        _deckNameText.text = deck.DeckName;

        ClearDeckList();

        foreach (var card in deck.Cards)
        {
            var itemGO = Instantiate(_deckCardPrefab, _deckListContent);
            var itemUI = itemGO.GetComponent<DeckCardPrefabController>();

            if (itemUI != null)
            {
                itemUI.SetCardDeckData(deck.DeckId, card.CardId, card.Quantity);
            }
            else
            {
                Debug.LogError("DeckUIEditorController: Prefab missing CardDeckPrefabController component!");
            }
        }
    }

    private void ClearDeckList()
    {
        foreach (Transform child in _deckListContent)
        {
            Destroy(child.gameObject);
        }
    }

    //REFRESH
    public async void RefreshDeck(int deckId)
    {
        try
        {
            await _deckListController.UpdateDeckListAsync();

            var updatedDeck = PlayerData.Instance.playerDecks
                .FirstOrDefault(d => d.DeckId == deckId);

            if (updatedDeck != null)
            {
                DisplayDeckContent(updatedDeck);
            }

        }
        catch (Exception ex)
        {
            Debug.LogError($"Error refreshing deck: {ex.Message}");
        }
    }
}

