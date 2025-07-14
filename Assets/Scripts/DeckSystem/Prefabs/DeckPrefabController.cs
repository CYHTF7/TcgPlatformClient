using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


public class DeckPrefabController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _deckNameText;
    [SerializeField] private GameObject _deckRemoveButton;

    //Logic References
    private DeckRemoveController _deckRemoveController;
    private DeckUIEditorController _deckUIEditorController;

    private Deck _deckData;

    private void Start()
    {
        if (_deckRemoveButton != null) 
        {
            _deckRemoveButton.SetActive(false);
        }
    }

    private void Awake()
    {
        if (_deckNameText == null || _deckRemoveButton == null)
        {
            Debug.LogError("DeckPrefabController: Invalid references!");
        }
    }

    public void SetDeckReferences(DeckUIEditorController editor, DeckRemoveController remover)
    {
        _deckUIEditorController = editor;
        _deckRemoveController = remover;
    }

    public void SetDeckData(Deck deck)
    {
        _deckData = deck;

        if (_deckData == null)
        {
            Debug.LogWarning("Deck data is null!");
            return;
        }

        if (_deckNameText != null)
        {
            _deckNameText.text = _deckData.DeckName;
        }
        else
        {
            Debug.LogWarning("Deck name text UI not set!");
        }
    }

    public void OnClick()
    {
        _deckUIEditorController.DisplayDeckContent(_deckData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _deckRemoveButton.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _deckRemoveButton.SetActive(false);
    }

    public void OnClickRemoveDeckButton()
    {
        if (_deckData == null)
        {
            Debug.LogError("Deck data is null, cannot remove deck.");
            return;
        }

        var dto = new DeckRemoveDTO
        {
            deckId = _deckData.DeckId,
            //playerId = PlayerData.Instance.Id
        };

        _deckRemoveController.ReciveDeckToRemove(dto);
    }
}
