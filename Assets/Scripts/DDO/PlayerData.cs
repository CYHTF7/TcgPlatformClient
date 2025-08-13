using System.Collections.Generic;
using UnityEngine;
using Boosters;
using Unity.VisualScripting;
using Cards;
using System.Linq;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance { get; private set; }

    //public int Id = 0000;
    public string Nickname = "";
    public int Level = 0;
    public int Gold = 0;
    public int Experience = 0;
    public string AvatarPath = "";
    public int BattlesPlayed = 0;
    public bool IsLoggedIn { get; set; }

    public List<Booster> playerBoosters = new List<Booster>();
    public Dictionary<int, int> boosterQuantities = new Dictionary<int, int>();

    public List<Card> playerCards = new List<Card>();
    public Dictionary<int, int> cardQuantities = new Dictionary<int, int>();

    public List<Deck> playerDecks = new List<Deck>();

    public class PlayerProfile
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public int Experience { get; set; }
        public string AvatarPath { get; set; }
        public int BattlesPlayed { get; set; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("PlayerData Instance set");
        }
        else
        {
            Debug.LogWarning("PlayerData instance already exists!");
            Destroy(gameObject);
        }
    }

    public void SetUserData(/*int id,*/ string nickname, int level, int gold, int experience, string avatarPath, int battlesPlayed)
    {
        if (PlayerData.Instance == null)
        {
            Debug.LogError("PlayerData.Instance is null!");
            return;
        }

        //Id = id;
        Nickname = nickname;
        Level = level;
        Gold = gold;
        Experience = experience;
        AvatarPath = avatarPath;
        BattlesPlayed = battlesPlayed;

        //
        IsLoggedIn = true;
    }

    public void SetUserBoosterData(List<BoosterLoadDTO> boosters, bool update)
    {
        if (Instance == null)
        {
            Debug.LogError("PlayerData.Instance is null!");
            return;
        }

        if (update == false)
        {
            playerBoosters.Clear();
            boosterQuantities.Clear();
        }

        foreach (var dbBooster in boosters)
        {
            var booster = BoosterDataStorage.Instance.boosterList
                .FirstOrDefault(b => b.BoosterId == dbBooster.id);

            if (booster != null)
            {
                if (!playerBoosters.Contains(booster))
                {
                    playerBoosters.Add(booster);
                    boosterQuantities[dbBooster.id] = dbBooster.quantity;
                }

                else
                {
                    boosterQuantities[dbBooster.id] += dbBooster.quantity;
                }
            }

            else
            {
                Debug.LogWarning($"Booster with ID {dbBooster.id} not found in boosterList!");
            }
        }

        Debug.Log($"Loaded {playerBoosters.Count} boosters for player {PlayerData.Instance}");

        Debug.Log("Booster Quantities:");
        foreach (var kvp in boosterQuantities)
        {
            Debug.Log($"BoosterId: {kvp.Key}, Quantity: {kvp.Value}");
        }
    }

    public void SetUserCardData(List<CardLoadDTO> cards, bool update)
    {
        if (Instance == null)
        {
            Debug.LogError("PlayerData.Instance is null!");
            return;
        }

        if (update == false)
        {
            playerCards.Clear();
            cardQuantities.Clear();
        }

        foreach (var dbCard in cards)
        {
            var combinedCard = CardDataStorage.Instance.combinedCardList
                .FirstOrDefault(card => card.CardId == dbCard.id);

            if (combinedCard != null)
            {
                if (!playerCards.Contains(combinedCard))
                {
                    playerCards.Add(combinedCard);
                    cardQuantities[dbCard.id] = dbCard.quantity;
                }

                else
                {
                    cardQuantities[dbCard.id] += dbCard.quantity;
                }
            }

            else
            {
                Debug.LogWarning($"Card with ID {dbCard.id} not found in combinedCardList!");
            }
        }

        Debug.Log($"Loaded {playerCards.Count} cards for player {PlayerData.Instance}");

        Debug.Log("Card Quantities:");
        foreach (var kvp in cardQuantities)
        {
            Debug.Log($"CardId: {kvp.Key}, Quantity: {kvp.Value}");
        }
    }

    public void SetUserDeckData(List<DeckLoadDTO> decks)
    {
        if (Instance == null)
        {
            Debug.LogError("PlayerData.Instance is null!");
            return;
        }

        playerDecks.Clear();

        foreach (var deckDTO in decks)
        {
            var deck = new Deck
            {
                DeckId = deckDTO.deckId,
                DeckName = deckDTO.deckName,
                PlayerId = deckDTO.playerId,
                Cards = new List<DeckCard>()
            };

            foreach (var cardDTO in deckDTO.cards)
            {
                var foundCard = CardDataStorage.Instance.combinedCardList?
                    .FirstOrDefault(c => c.CardId == cardDTO.cardId);

                if (foundCard != null)
                {
                    deck.Cards.Add(new DeckCard
                    {
                        CardId = foundCard.id,
                        Quantity = cardDTO.quantity
                    });
                }
                else
                {
                    Debug.LogWarning($"Card ID {cardDTO.cardId} not found!");
                }
            }

            playerDecks.Add(deck);
        }

        Debug.Log($"Updated decks. Total: {playerDecks.Count}");
    }
}

//public void SetUserDeckData(List<DeckLoadDTO> decks) mat be like this?
//{
//    if (Instance == null)
//    {
//        Debug.LogError("PlayerData.Instance is null!");
//        return;
//    }

//    var newDecks = new List<Deck>(decks.Count);

//    foreach (var deckDTO in decks)
//    {
//        var deck = new Deck
//        {
//            DeckId = deckDTO.deckId,
//            DeckName = deckDTO.deckName,
//            PlayerId = deckDTO.playerId,
//            Cards = new List<DeckCard>(deckDTO.cards.Count)
//        };

//        foreach (var cardDTO in deckDTO.cards)
//        {
//            var foundCard = CardDataStorage.Instance.combinedCardList?
//                .FirstOrDefault(c => c.CardId == cardDTO.cardId);

//            if (foundCard != null)
//            {
//                deck.Cards.Add(new DeckCard
//                {
//                    CardId = foundCard.id,
//                    Quantity = cardDTO.quantity
//                });
//            }
//        }
//        newDecks.Add(deck);
//    }

//    playerDecks = newDecks;

//    Debug.Log($"Updated {playerDecks.Count} decks");
//} 