using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UI;

public class DeckRemoveController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Button _deckRemoveButton;

    [Header("Logic References")]
    [SerializeField] private DeckListController _deckListController;
    [SerializeField] private DeckUIController _deckUIController;

    private DeckRemoveDTO deckToRemove;

    private void Awake()
    {
        if (_deckListController == null || _deckUIController == null)
        {
            Debug.LogError("DeckRemoveController: Invalid references!");
        }
    }

    public void ReciveDeckToRemove(DeckRemoveDTO deck)
    {
        deckToRemove = deck;

        _deckUIController.ShowDeckRemovePanel();
    }

    public void BackButton()
    {
        _deckUIController.ShowDeckListPanel();
    }

    public void DeckRemoveButton()
    {
        SendDeckToRemove(); 
    }

    public async Task SendDeckToRemove()
    {
        if (deckToRemove == null)
        {
            Debug.LogError("No deck selected for deletion.");
            return;
        }

        var deckList = new List<DeckRemoveDTO> { deckToRemove };

        LoadStageManager.Instance.Show();
        _deckRemoveButton.interactable = false;

        await ApiClient.RemoveDecksAsync(deckList);

        await _deckListController.UpdateDeckListAsync();

        LoadStageManager.Instance.Hide();
        _deckRemoveButton.interactable = true;

        _deckUIController.ShowDeckListPanel();
    }
}

