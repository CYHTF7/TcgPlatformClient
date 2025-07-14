using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cards;

public class CollectionLoader : MonoBehaviour
{
    [Header("References")]
    public GameObject Card;
    public GameObject CardCount;
    public Transform Grid; 
    public int cardsPerPage = 6; 
    public UnityEngine.UI.Button NextPageButton; 
    public UnityEngine.UI.Button PreviousPageButton;
    public UnityEngine.UI.Button FilterManaCostButton;
    public UnityEngine.UI.Button FilterIDButton;
    public UnityEngine.UI.Button FilterAllButton;
    public UnityEngine.UI.Button FilterPlayerButton;
    public TextMeshProUGUI pageCounter;

    private List<Card> combinedCardList = new List<Card>();
    public bool allCardList = false;
    private List<Card> combinedPlayerCardList = new List<Card>();

    private int currentPage = 0; 

    private void Start()
    {
        if (CardDataStorage.Instance == null)
        {
            Debug.LogError("Error! CardDataStorage.Instance not set!");
            return;
        }

        LoadCombinedCardList();
        LoadCombinedPlayerCardList();

        SetupButtons();

        FilterPlayerLoader();
    }

    private void LoadCombinedCardList()
    {
        combinedCardList.AddRange(CardDataStorage.Instance.combinedCardList);
        Debug.Log($"Loader all cards: {CardDataStorage.Instance.combinedCardList.Count}");
    }
    private void LoadCombinedPlayerCardList()
    {
        combinedPlayerCardList.Clear();
        combinedPlayerCardList.AddRange(PlayerData.Instance.playerCards);
        Debug.Log($"Loader player cards: {PlayerData.Instance.playerCards.Count}");
    }

    private void SetupButtons()
    {
        //pages
        if (NextPageButton != null)
        {
            NextPageButton.onClick.AddListener(() => ChangePage(1));
        }

        if (PreviousPageButton != null)
        {
            PreviousPageButton.onClick.AddListener(() => ChangePage(-1));
        }
        //filters
        if (FilterManaCostButton != null)
        {
            FilterManaCostButton.onClick.AddListener(FilterManaCostLoader);
        }

        if (FilterIDButton != null)
        {
            FilterIDButton.onClick.AddListener(FilterIDLoader);
        }
        if (FilterAllButton != null)
        {
            FilterAllButton.onClick.AddListener(FilterAllLoader);
        }
        if (FilterPlayerButton != null)
        {
            FilterPlayerButton.onClick.AddListener(FilterPlayerLoader);
        }
        UpdateButtonStates();
    }

    private void DisplayPage(int pageIndex)
    {
        //clean page (delete all cards)
        foreach (Transform child in Grid)
        {
            Destroy(child.gameObject);
        }

        //card count for page
        int startIndex = pageIndex * cardsPerPage;
        int endIndex = Mathf.Min(startIndex + cardsPerPage, combinedCardList.Count);

        //creating cards
        for (int i = startIndex; i < endIndex; i++)
        {
            var card = combinedCardList[i];

            GameObject newCard = Instantiate(Card, Grid);

            CardLoader cardLoader = newCard.GetComponent<CardLoader>();
            if (cardLoader != null)
            {
                int cardId = GetCardId(card);
                cardLoader.SetCardId(cardId);
            }
            else
            {
                Debug.LogWarning("Prefab don't have CardLoader!");
            }
        }

        UpdateButtonStates();
    }

    private void DisplayPlayerPage(int pageIndex)
    {
        //clean page (delete all cards)
        foreach (Transform child in Grid)
        {
            Destroy(child.gameObject);
        }

        //card count for page
        int startIndex = pageIndex * cardsPerPage;
        int endIndex = Mathf.Min(startIndex + cardsPerPage, combinedPlayerCardList.Count);

        //creating cards
        for (int i = startIndex; i < endIndex; i++)
        {
            var card = combinedPlayerCardList[i];

            GameObject newCard = Instantiate(CardCount, Grid);

            CardLoader cardLoader = newCard.GetComponent<CardLoader>();
            if (cardLoader != null)
            {
                int cardId = GetCardId(card);
                cardLoader.SetCardCountId(cardId);
            }
            else
            {
                Debug.LogWarning("Prefab don't have CardLoader!");
            }
        }

        UpdateButtonStates();
    }

    private void ChangePage(int direction)
    {
        if (allCardList) 
        {
            int totalPages = Mathf.CeilToInt((float)combinedCardList.Count / cardsPerPage);
            currentPage = Mathf.Clamp(currentPage + direction, 0, totalPages - 1);
            DisplayPage(currentPage);
        }

        if (!allCardList) 
        {
            int totalPages = Mathf.CeilToInt((float)combinedPlayerCardList.Count / cardsPerPage);
            currentPage = Mathf.Clamp(currentPage + direction, 0, totalPages - 1);
            DisplayPlayerPage(currentPage);
        }    
    }

    private void UpdateButtonStates()
    {
        pageCounter.text = (currentPage+1).ToString();

        int totalPages = allCardList ? Mathf.CeilToInt((float)combinedCardList.Count / cardsPerPage) : Mathf.CeilToInt((float)combinedPlayerCardList.Count / cardsPerPage);

        if (PreviousPageButton != null)
        {
            PreviousPageButton.interactable = currentPage > 0;
        }

        if (NextPageButton != null)
        {
            NextPageButton.interactable = currentPage < totalPages - 1;
        }
    }

    public void FilterIDLoader() 
    {
        if (allCardList) 
        {
            FilterIDButtonFX();
            combinedCardList.Sort((a, b) =>
            {
                int idA = GetCardId(a);
                int idB = GetCardId(b);
                return idA.CompareTo(idB);
            });
            DisplayPage(currentPage);
        }
        else
        {
            FilterIDButtonFX();
            combinedPlayerCardList.Sort((a, b) =>
            {
                int idA = GetCardId(a);
                int idB = GetCardId(b);
                return idA.CompareTo(idB);
            });
            DisplayPlayerPage(currentPage);
        }
    }

    public void FilterManaCostLoader()
    {
        FilterIDLoader();
        FilterManaCostButtonFX();

        if (allCardList)
        {
            combinedCardList.Sort((a, b) =>
            {
                int idA = GetCardManaCost(a);
                int idB = GetCardManaCost(b);
                return idA.CompareTo(idB);
            });
            DisplayPage(currentPage);
        }
        else
        {
            combinedPlayerCardList.Sort((a, b) =>
            {
                int idA = GetCardManaCost(a);
                int idB = GetCardManaCost(b);
                return idA.CompareTo(idB);
            });
            DisplayPlayerPage(currentPage);
        }
    }

    public void FilterPlayerLoader() 
    {
        allCardList = false;
        currentPage = 0;
        FilterPlayerButtonFX();
        FilterIDLoader();

    }

    public void FilterAllLoader()
    {
        allCardList = true;
        currentPage = 0;
        FilterAllButtonFX();
        FilterIDLoader();

    }

    private int GetCardId(Card card)
    {
        if (card is Card cardClass)
        {
            return cardClass.id;
        }

        Debug.LogWarning("Unknown card type: " + card.GetType());
        return -1;
    }


    private int GetCardManaCost(Card card)
    {
        if (card is Card cardClass)
        {
            return cardClass.manaCost;
        }

        Debug.LogWarning("Unknown card type: " + card.GetType());
        return -1;
    }

    void FilterManaCostButtonFX() 
    {
        RectTransform rectTransformFilterManaCostButton = FilterManaCostButton.GetComponent<RectTransform>();
        RectTransform rectTransformFilterIDButton = FilterIDButton.GetComponent<RectTransform>();
        rectTransformFilterManaCostButton.anchoredPosition = new Vector3(-303, 155, 0);
        rectTransformFilterIDButton.anchoredPosition = new Vector3(-344, 165, 0);
    }

    void FilterIDButtonFX() 
    {
        RectTransform rectTransformFilterManaCostButton = FilterManaCostButton.GetComponent<RectTransform>();
        RectTransform rectTransformFilterIDButton = FilterIDButton.GetComponent<RectTransform>();
        rectTransformFilterIDButton.anchoredPosition = new Vector3(-344, 155, 0);
        rectTransformFilterManaCostButton.anchoredPosition = new Vector3(-303, 165, 0);
    }

    void FilterAllButtonFX()
    {
        RectTransform rectTransformFilterAllButton = FilterAllButton.GetComponent<RectTransform>();
        RectTransform rectTransformFilterPlayerButton = FilterPlayerButton.GetComponent<RectTransform>();
        rectTransformFilterAllButton.anchoredPosition = new Vector3(185, 155, 0);
        rectTransformFilterPlayerButton.anchoredPosition = new Vector3(144, 165, 0);
    }

    void FilterPlayerButtonFX()
    {
        RectTransform rectTransformFilterAllButton = FilterAllButton.GetComponent<RectTransform>();
        RectTransform rectTransformFilterPlayerButton = FilterPlayerButton.GetComponent<RectTransform>();
        rectTransformFilterAllButton.anchoredPosition = new Vector3(185, 165, 0);
        rectTransformFilterPlayerButton.anchoredPosition = new Vector3(144, 155, 0);
    }
}