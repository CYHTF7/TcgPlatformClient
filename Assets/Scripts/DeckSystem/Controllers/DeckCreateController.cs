using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UI;

public class DeckCreateController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_InputField _deckNameInputField;
    [SerializeField] private Button _deckCreateButton;

    [Header("Logic References")]
    [SerializeField] private DeckListController _deckListController;
    [SerializeField] private DeckUIController _deckUIController;

    private void Awake()
    {
        if (_deckNameInputField == null || _deckListController == null || _deckUIController == null)
        {
            Debug.LogError("DeckCreateController: Invalid references!");
        }
    }

    public void BackButton() 
    {
        _deckUIController.ShowDeckListPanel();
    }

    public void DeckCreateButton() 
    {
        SendNewDeck();
    }

    public async Task SendNewDeck() 
    {
        if (string.IsNullOrWhiteSpace(_deckNameInputField.text))
        {
            LogManager.Instance.Log("Deck name cannot be empty!");
            return;
        }

        DeckLoadDTO newDeck = new DeckLoadDTO
        {
            deckId = 0,
            deckName = _deckNameInputField.text,
            cards = new List<DeckCardLoadDTO>()
        };

        var newDeckList = new List<DeckLoadDTO> { newDeck };

        _deckCreateButton.interactable = false;
        LoadStageManager.Instance.Show();

        await ApiClient.AddOrUpdateDecksAsync(newDeckList);

        await _deckListController.UpdateDeckListAsync();

        _deckCreateButton.interactable = true;
        LoadStageManager.Instance.Hide();

        _deckUIController.ShowDeckListPanel();
    }
}
        