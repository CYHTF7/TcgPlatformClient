using UnityEngine;
using TMPro;

public class DeckUIEditorController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _deckNameText;
    [SerializeField] private Transform _deckListContent;
    [SerializeField] private GameObject _deckCardPrefab;

    [Header("Logic References")]
    [SerializeField] private DeckUIController _deckUIController;

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

        _deckUIController.ShowDeckEditorPanel();

        _deckNameText.text = deck.DeckName;

        ClearDeckList();

        foreach (var card in deck.Cards)
        {
            var itemGO = Instantiate(_deckCardPrefab, _deckListContent);
            var itemUI = itemGO.GetComponent<DeckCardPrefabController>();

            if (itemUI != null)
            {
                itemUI.SetCardDeckData(card.CardId, card.Quantity);
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
}

