using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cards;

public class CardLoader : MonoBehaviour
{
    [Header("Card Data")]
    [SerializeField]
    private int cardId;

    [Header("UI References")]
    public Image cardImage;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI manaCostText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI countText;

    public void SetCardId(int id)
    {
        cardId = id;
        LoadCardData();
    }
    public void SetCardCountId(int id)
    {
        cardId = id;
        LoadCardCountData();
    }

    private void LoadCardData()
    {
        if (CardDataStorage.Instance == null)
        {
            Debug.LogWarning("CardDataStorage.Instance or combinedCardList not set!");
            return;
        }

        //find card id
        var cardObject = CardDataStorage.Instance.combinedCardList.Find(c =>
            (c is CardAlly && ((CardAlly)c).id == cardId) ||
            (c is CardAbility && ((CardAbility)c).id == cardId) ||
            (c is CardHero && ((CardHero)c).id == cardId)
            );

        if (cardObject == null)
        {
            Debug.LogWarning($"Card ID: {cardId} not found!");
            return;
        }

        if (cardObject is CardAlly cardAlly)
        {
            //for ally
            manaCostText.text = cardAlly.manaCost.ToString();
            healthText.text = cardAlly.baseHp.ToString();
            var attackDDE = cardAlly.effects.Find(effect => effect is DealDamageEffect) as DealDamageEffect;
            attackText.text = attackDDE.damage.ToString();

            Sprite sprite = Resources.Load<Sprite>(cardAlly.image);
            if (sprite != null)
            {
                cardImage.sprite = sprite;
            }
            else
            {
                Debug.LogWarning($"Image for {cardAlly.image} not found!");
            }
        }
        else if (cardObject is CardAbility cardAbility)
        {
            //for ability
            manaCostText.text = cardAbility.manaCost.ToString();
            healthText.text = "";
            attackText.text = "";

            Sprite sprite = Resources.Load<Sprite>(cardAbility.image);
            if (sprite != null)
            {
                cardImage.sprite = sprite;
            }
            else
            {
                Debug.LogWarning($"Image for {cardAbility.image} not found!");
            }
        }
        if (cardObject is CardHero cardHero)
        {
            //for hero
            manaCostText.text = "";
            attackText.text = "";
            healthText.text = cardHero.baseHp.ToString();

            Sprite sprite = Resources.Load<Sprite>(cardHero.image);
            if (sprite != null)
            {
                cardImage.sprite = sprite;
            }
            else
            {
                Debug.LogWarning($"Image for {cardHero.image} not found!");
            }
        }
    }
    private void LoadCardCountData()
    {
        if (CardDataStorage.Instance == null)
        {
            Debug.LogWarning("CardDataStorage.Instance or combinedCardList not set!");
            return;
        }

        //find card id
        var cardObject = CardDataStorage.Instance.combinedCardList.Find(c =>
            (c is CardAlly && ((CardAlly)c).id == cardId) ||
            (c is CardAbility && ((CardAbility)c).id == cardId) ||
            (c is CardHero && ((CardHero)c).id == cardId)
            );

        if (cardObject == null)
        {
            Debug.LogWarning($"Card ID: {cardId} not found!");
            return;
        }

        if (cardObject is CardAlly cardAlly)
        {
            //for ally
            manaCostText.text = cardAlly.manaCost.ToString();
            healthText.text = cardAlly.baseHp.ToString();
            var attackDDE = cardAlly.effects.Find(effect => effect is DealDamageEffect) as DealDamageEffect;
            attackText.text = attackDDE.damage.ToString();
            countText.text = $"{PlayerData.Instance.cardQuantities[cardObject.id]}";

            Sprite sprite = Resources.Load<Sprite>(cardAlly.image);
            if (sprite != null)
            {
                cardImage.sprite = sprite;
            }
            else
            {
                Debug.LogWarning($"Image for {cardAlly.image} not found!");
            }
        }
        else if (cardObject is CardAbility cardAbility)
        {
            //for ability
            manaCostText.text = cardAbility.manaCost.ToString();
            healthText.text = "";
            attackText.text = "";
            countText.text = $"{PlayerData.Instance.cardQuantities[cardObject.id]}";

            Sprite sprite = Resources.Load<Sprite>(cardAbility.image);
            if (sprite != null)
            {
                cardImage.sprite = sprite;
            }
            else
            {
                Debug.LogWarning($"Image for {cardAbility.image} not found!");
            }
        }
        if (cardObject is CardHero cardHero)
        {
            //for hero
            manaCostText.text = "";
            attackText.text = "";
            healthText.text = cardHero.baseHp.ToString();
            countText.text = $"{PlayerData.Instance.cardQuantities[cardObject.id]}";

            Sprite sprite = Resources.Load<Sprite>(cardHero.image);
            if (sprite != null)
            {
                cardImage.sprite = sprite;
            }
            else
            {
                Debug.LogWarning($"Image for {cardHero.image} not found!");
            }
        }
    }
}