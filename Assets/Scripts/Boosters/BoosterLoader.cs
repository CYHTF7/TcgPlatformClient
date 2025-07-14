using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Boosters;

public class BoosterLoader : MonoBehaviour
{
    [Header("Card Data")]
    [SerializeField]
    private int boosterId;

    [Header("UI References")]
    public Image boosterImage;

    private void Awake()
    {
        SetBoosterId(boosterId);
    }

    public void SetBoosterId(int id)
    {
        boosterId = id;
        LoadBoosterData();
    }

    private void LoadBoosterData()
    {
        if (BoosterDataStorage.Instance == null)
        {
            Debug.LogWarning("BoosterDataStorage.Instance or boosterList not set!");
            return;
        }

        var boosterObject = BoosterDataStorage.Instance.boosterList.Find(c => c.id == boosterId);

        if (boosterObject == null)
        {
            Debug.LogWarning($"Card ID: {boosterId} not found!");
            return;
        }

        Sprite sprite = Resources.Load<Sprite>(boosterObject.image);
        if (sprite != null)
        {
            boosterImage.sprite = sprite;
        }
        else
        {
            Debug.LogWarning($"Image for {boosterObject.image} not found!");
        }
    }
}
