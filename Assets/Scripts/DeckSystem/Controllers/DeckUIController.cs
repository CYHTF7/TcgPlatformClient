using UnityEngine;

public class DeckUIController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject _deckListPanel;
    [SerializeField] private GameObject _deckEditorPanel;
    [SerializeField] private GameObject _removeDeckPanel;
    [SerializeField] private GameObject _createDeckPanel;
    [SerializeField] private GameObject _blockZoneAll;
    [SerializeField] private GameObject _blockZoneCollection;

    private void Start()
    {
        ShowDeckListPanel();
    }

    public void ShowDeckListPanel()
    {
        _deckListPanel.SetActive(true);
        _deckEditorPanel.SetActive(false);
        _removeDeckPanel.SetActive(false);
        _createDeckPanel.SetActive(false);
        _blockZoneAll.SetActive(false);
        _blockZoneCollection.SetActive(false);
    }

    public void ShowDeckEditorPanel()
    {
        _deckListPanel.SetActive(false);
        _deckEditorPanel.SetActive(true);
        _removeDeckPanel.SetActive(false);
        _createDeckPanel.SetActive(false);
    }

    public void ShowDeckRemovePanel()
    {
        _deckListPanel.SetActive(true);
        _deckEditorPanel.SetActive(false);
        _removeDeckPanel.SetActive(true);
        _createDeckPanel.SetActive(false);
    }

    public void ShowDeckCreatePanel()
    {
        _deckListPanel.SetActive(true);
        _deckEditorPanel.SetActive(false);
        _removeDeckPanel.SetActive(false);
        _createDeckPanel.SetActive(true);
    }
}

