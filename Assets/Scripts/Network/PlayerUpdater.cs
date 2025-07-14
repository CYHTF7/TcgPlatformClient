using UnityEngine;
using System.Threading.Tasks;
using System;

public static class PlayerUpdater
{
    public static async Task AddGold(int amount)
    {
        if (PlayerData.Instance != null)
        {
            PlayerData.Instance.Gold += amount;
            try
            {
                bool success = await ApiClient.UpdateProfileAsync();

                if (success)
                {
                    Debug.Log("Profile updated successfully!");
                }
                else
                {
                    Debug.LogError("Failed to update profile.");
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error updating profile: {ex.Message}");
            }
        }
        else
        {
            Debug.LogError("PlayerData.Instance is null!");
        }
    }

    public static async Task RemoveGold(int amount) 
    {
        if (PlayerData.Instance != null)
        {
            PlayerData.Instance.Gold -= amount;
            try
            {
                bool success = await ApiClient.UpdateProfileAsync();

                if (success)
                {
                    Debug.Log("Profile updated successfully!");
                }
                else
                {
                    Debug.LogError("Failed to update profile.");
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error updating profile: {ex.Message}");
            }
        }
        else
        {
            Debug.LogError("PlayerData.Instance is null!");
        }
    }
}


