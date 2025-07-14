using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AuthManager : MonoBehaviour
{
    public static AuthManager Instance { get; private set; }

    public string AccessToken = "";
    public string RefreshToken = "";
    public DateTime RefreshTokenExpiryTime = DateTime.MinValue;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("AuthManager Instance set");
        }
        else
        {
            Debug.LogWarning("AuthManager instance already exists!");
            Destroy(gameObject);
        }
    }

    public void SetJwtToken(string accessToken, string refreshToken, DateTime refreshTokenExpiryTime) 
    {
        if (Instance == null)
        {
            Debug.LogError("PlayerData.Instance is null!");
            return;
        }

        AccessToken = accessToken;
        RefreshToken = refreshToken;
        RefreshTokenExpiryTime = refreshTokenExpiryTime;
    }
}
