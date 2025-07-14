using Boosters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class BoosterBuySystem : MonoBehaviour
{
    [SerializeField] private MainStore mainStore;

    public void OnBuyBooster11ButtonClick()
    {
        BuyBooster11Button();
    }

    public async void BuyBooster11Button()
    {
        LoadStageManager.Instance.Show();

        if (PlayerData.Instance.IsLoggedIn == false) 
        {
            LogManager.Instance.Log("Please go to Profile and login!");
        }

        else if  (PlayerData.Instance.Gold >= 100)
        {
            await BuyBooster11();
        }

        else 
        {
            LogManager.Instance.Log("Need more gold!");
        }

        LoadStageManager.Instance.Hide();
    }

    private async Task BuyBooster11()
    {
        await PlayerUpdater.RemoveGold(100);

        mainStore.UpdateSceneUI();

        var obtainedBoosters = BoosterDataStorage.Instance.boosterList
            .Where(booster => booster.id == 11).ToList();

        Debug.Log(obtainedBoosters);

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

        await ApiClient.AddBoostersAsync(boosterRequests);

        await ApiClient.LoadBoostersAsync();
    }
}
