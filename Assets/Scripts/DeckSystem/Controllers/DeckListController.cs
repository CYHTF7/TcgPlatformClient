using UnityEngine;
using System.Threading.Tasks;
using System;

public class DeckListController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject _deckPrefab;
    [SerializeField] private Transform _deckListContent;

    [Header("Logic References")]
    [SerializeField] private DeckUIEditorController _deckUIEditorController;
    [SerializeField] private DeckRemoveController _deckRemoveController;
    [SerializeField] private DeckUIController _deckUIController;

    private void Awake()
    {
        if (_deckPrefab == null || _deckListContent == null || _deckUIController == null)
        {
            Debug.LogError("DeckListController: Invalid references!");
        }
    }

    private void Start()
    {
        LoadDeckList();
    }

    public async Task UpdateDeckListAsync()
    {
        try
        {
            await ApiClient.LoadDecksAsync();
            LoadDeckList();
        }
        catch (Exception ex)
        {
            LogManager.Instance.Log("Failed to update decks!}");
            Debug.LogError($"Failed to update decks: {ex.Message}");
        }
    }

    public void LoadDeckList()
    {
        var decks = PlayerData.Instance.playerDecks;

        ClearDeckList();

        foreach (var deck in decks)
        {
            var deckGO = Instantiate(_deckPrefab, _deckListContent);
            var deckUI = deckGO.GetComponent<DeckPrefabController>();

            if (deckUI != null)
            {
                deckUI.SetDeckReferences(_deckUIEditorController, _deckRemoveController);
                deckUI.SetDeckData(deck);
            }
            else
            {
                Debug.LogError("DeckListController: Prefab missing DeckPrefabController component!");
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

    public void OpenCreateDeckPanelButton()
    {
        if (PlayerData.Instance.IsLoggedIn == false)
        {
            LogManager.Instance.Log("Login first!");
            return;
        }
        _deckUIController.ShowDeckCreatePanel();
    }
}







