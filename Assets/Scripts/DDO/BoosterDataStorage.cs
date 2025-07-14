using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boosters;

public class BoosterDataStorage : MonoBehaviour
{
    public static BoosterDataStorage Instance;

    public List<Booster> boosterList = new List<Booster>();

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
            LoadBoosterData();
        }
    }
    public void LoadBoosterData()
    {
        try
        {
            boosterList = BoosterDataBase.GetAllBoosters();

            if (boosterList != null)
            {
                Debug.Log($"Loaded! Boosters: {boosterList.Count}");
            }
            else
            {
                Debug.LogWarning("Warning! Boosters not loaded!");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Error! Boosters not loaded: {ex.Message}");
        }
    }
}
