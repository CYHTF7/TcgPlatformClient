using System.Collections.Generic;
using UnityEngine;
using Cards;
using System;

public class CardDataStorage : MonoBehaviour
{
    public static CardDataStorage Instance;

    public List<CardAbility> cardListAbility = new List<CardAbility>();
    public List<CardAlly> cardListAlly = new List<CardAlly>();
    public List<CardHero> cardListHero = new List<CardHero>();
    public List<Card> combinedCardList = new List<Card>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadCardAllyData();
            LoadCardAbilityData();
            LoadCardHeroData();
        }
    }
    public void LoadCardAllyData()
    {
        try
        {
            cardListAlly = CardDataAllyBase.GetAllAllyCards();

            combinedCardList.AddRange(cardListAlly);

            if (cardListAlly != null && cardListAlly.Count > 0)
            {
                Debug.Log($"Loaded! Ally cards: {cardListAlly.Count}");
            }
            else
            {
                Debug.LogWarning("Warning! Ally cards not loaded!");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error! Ally cards not loaded: {ex.Message}");
        }
    }

    public void LoadCardAbilityData()
    {
        try
        {
            cardListAbility = CardDataAbilityBase.GetAllAbilityCards();

            combinedCardList.AddRange(cardListAbility);

            if (cardListAbility != null && cardListAbility.Count > 0)
            {
                Debug.Log($"Loaded! Ability cards: {cardListAbility.Count}");
            }
            else
            {
                Debug.LogWarning("Warning! Ability cards not loaded!");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error! Ability cards not loaded: {ex.Message}");
        }
    }
    public void LoadCardHeroData()
    {
        try
        {
            cardListHero = CardDataHeroBase.GetAllHeroCards();

            combinedCardList.AddRange(cardListHero);

            if (cardListHero != null && cardListHero.Count > 0)
            {
                Debug.Log($"Loaded! Hero cards: {cardListHero.Count}");

                //all in last loader
                Debug.Log($"Loaded! All cards: {combinedCardList.Count}");
            }
            else
            {
                Debug.LogWarning("Warning! Hero cards not loaded!");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error! Hero cards not loaded: {ex.Message}");
        }
    }
}


