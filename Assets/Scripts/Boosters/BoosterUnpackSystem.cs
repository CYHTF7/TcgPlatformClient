using Boosters;
using Cards;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class BoosterUnpackSystem : MonoBehaviour
{
    [SerializeField] PlayerData playerData;

    [SerializeField] MainUnpackBooster mainUnpackBooster;

    public RectTransform cardContainer;

    public GameObject cardPrefab;

    private List<Vector2> placedPositions = new List<Vector2>();

    public void OnUnpackBoosterButtonClick()
    {
        UnpackBoosterButton();
    }

    public async void UnpackBoosterButton()
    {
        LoadStageManager.Instance.Show();

        if ((PlayerData.Instance.boosterQuantities.TryGetValue(11, out int boosterCount) && boosterCount >= 1))
        {
            await UnpackBooster();
        }
        else 
        {
            LogManager.Instance.Log("Need more boosters!");
        }

        LoadStageManager.Instance.Hide();
    }

    private static Dictionary<Rarity, float> rarityChances = new Dictionary<Rarity, float>
    {
        { Rarity.Common, 65f },
        { Rarity.Uncommon, 29.5f },
        { Rarity.Rare, 4f },
        { Rarity.RareGold, 0.5f },
        { Rarity.Epic, 1f }
    };

    public async Task <List<Card>> UnpackBooster()
    {
        List<Card> obtainedCards = new List<Card>();

        if (PlayerData.Instance.boosterQuantities == null)
        {
            Debug.Log("Booster quantities data is missing!");
        }

        if (PlayerData.Instance.boosterQuantities.TryGetValue(11, out int boosterCount) && boosterCount >= 1)
        {
            for (int i = 0; i < 10; i++)
            {
                Rarity selectedRarity = GetRandomRarity();
                Card selectedCard = GetRandomCardByRarity(selectedRarity);

                if (selectedCard != null)
                {
                    obtainedCards.Add(selectedCard);
                }
            }

            await SendCardsToServer(obtainedCards);
        }
        else
        {
            LogManager.Instance.Log("Need more boosters!");
        }

        DisplayCards(obtainedCards);

        return obtainedCards;
    }

    private Rarity GetRandomRarity()
    {
        float totalChance = rarityChances.Values.Sum();
        float randomValue = Random.Range(0, totalChance);
        float cumulative = 0f;

        foreach (var entry in rarityChances)
        {
            cumulative += entry.Value;
            if (randomValue <= cumulative)
                return entry.Key;
        }

        return Rarity.Common; 
    }

    private Card GetRandomCardByRarity(Rarity rarity)
    {
        var availableCards = CardDataStorage.Instance.combinedCardList
            .Where(card => card.rarity == rarity)
            .ToList();

        if (availableCards.Count == 0)
            return null;

        return availableCards[Random.Range(0, availableCards.Count)];
    }

    private async Task SendCardsToServer(List<Card> cards)
    {
        //int playerId = PlayerData.Instance.Id;

        List<CardUploadDTO> cardRequests = cards.GroupBy(c => c.CardId)
            .Select(group => new CardUploadDTO
            {
                //playerId = playerId,
                cardId = group.Key,
                quantity = group.Count()
            })
            .ToList();

        Debug.Log($"Sending cards result: {JsonConvert.SerializeObject(cardRequests)}");

        await RemoveBooster();

        await ApiClient.AddCardsAsync(cardRequests);

        await ApiClient.LoadCardsAsync();

    }

    private async Task RemoveBooster()
    {
        var obtainedBoosters = BoosterDataStorage.Instance.boosterList
            .Where(booster => booster.id == 11)
            .ToList();

        Debug.Log(obtainedBoosters);

        if (obtainedBoosters.Count == 0)
        {
            return;
        }

        await SendBoostersToServer(obtainedBoosters);
    }

    private async Task SendBoostersToServer(List<Booster> boosters)
    {
        //int playerId = PlayerData.Instance.Id;

        List<BoosterUploadDTO> boosterRequests = boosters.GroupBy(c => c.BoosterId)
            .Select(group => new BoosterUploadDTO
            {
                //playerId = playerId,
                boosterId = group.Key,
                quantity = group.Count()
            })
            .ToList();

        Debug.Log($"Sending boosters to server result: {JsonConvert.SerializeObject(boosterRequests)}");

        await ApiClient.RemoveBoostersAsync(boosterRequests);

        await ApiClient.LoadBoostersAsync();

        mainUnpackBooster.UpdateSceneUI();

        Debug.Log("UPDATED UNPACKUI");
    }

    private void DisplayCards(List<Card> obtainedCards)
    {

        foreach (Transform child in cardContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var card in obtainedCards)
        {
            GameObject newCard = Instantiate(cardPrefab, cardContainer);

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

            Canvas cardCanvas = newCard.GetComponent<Canvas>();
            if (cardCanvas != null)
            {
                cardCanvas.sortingOrder = cardContainer.GetSiblingIndex();
            }

            RectTransform cardTransform = newCard.GetComponent<RectTransform>();
            if (cardTransform != null)
            {
                SetRandomPosition(cardTransform);
            }
        }
    }

    private void SetRandomPosition(RectTransform cardTransform)
    {
        float width = cardContainer.rect.width / 2 + 150;
        float height = cardContainer.rect.height / 2 + 100;
        float minDistance = 50f;

        Vector2 newPosition = Vector2.zero;

        for (int attempts = 0; attempts < 10; attempts++)
        {
            float randomX = Random.Range(-width, width);
            float randomY = Random.Range(-height, height);
            newPosition = new Vector2(randomX, randomY);

            bool positionIsValid = true;

            foreach (var placedPos in placedPositions)
            {
                if (Vector2.Distance(newPosition, placedPos) < minDistance)
                {
                    positionIsValid = false;
                    break;
                }
            }

            if (positionIsValid)
            {
                break;
            }
        }

        placedPositions.Add(newPosition); 

        cardTransform.localScale = new Vector3(1f, 1f, 1f);
        cardTransform.rotation = Quaternion.Euler(0, 0, Random.Range(-20f, 20f));
        cardTransform.anchoredPosition = newPosition;
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

}