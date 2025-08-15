using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public static class ApiClient
{
    //UPDTAEPROFILE
    public static async Task<bool> UpdateProfileAsync()
    {
        var url = "https://localhost:7193/api/profile/updateprofile";

        var payload = new
        {
            PlayerData.Instance.Nickname,
            PlayerData.Instance.Level,
            PlayerData.Instance.Gold,
            PlayerData.Instance.Experience,
            PlayerData.Instance.AvatarPath,
            PlayerData.Instance.BattlesPlayed
        };

        string jsonPayload = JsonConvert.SerializeObject(payload);

        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonPayload);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            request.SetRequestHeader("Authorization", $"Bearer {AuthManager.Instance.AccessToken}");

            var operation = request.SendWebRequest();

            try
            {
                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("Profile update successful!");
                    return true;
                }
                else
                {
                    Debug.LogError($"Profile update failed: {request.error}");
                    return false;
                }
            }

            catch (Exception ex)
            {
                Debug.LogError($"Exception occurred: {ex.Message}");
                return false;
            }
        }
    }

    //REG
    public static async Task<string> RegisterProfileAsync(string nickname, string email, string password)
    {
        var url = "https://localhost:7193/api/regverlog/register";

        var payload = new
        {
            Nickname = nickname,
            Email = email,
            Password = password
        };

        string jsonPayload = JsonConvert.SerializeObject(payload);
        Debug.Log($"Serialized JSON payload: {jsonPayload}");

        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonPayload);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            try
            {
                var operation = request.SendWebRequest();
                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("Registration successful!");
                    PlayerPrefs.SetString("Email", email);
                    return request.downloadHandler.text;
                }
                else
                {
                    Debug.LogError($"Registration failed. Error: {request.error}, Response Code: {request.responseCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Exception occurred: {ex.Message}");
                return null;
            }
        }
    }

    //VER
    public static async Task<string> VerifyProfileAsync(string emailCode)
    {
        string email = PlayerPrefs.GetString("Email");

        var url = "https://localhost:7193/api/regverlog/verify";
        var payload = new
        {
            EmailCode = emailCode,
            Email = email
        };

        string jsonPayload = JsonConvert.SerializeObject(payload);
        Debug.Log($"Serialized JSON payload: {jsonPayload}");

        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonPayload);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            try
            {
                var operation = request.SendWebRequest();
                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("Verefication successful!");
                    return request.downloadHandler.text;
                }
                else
                {
                    Debug.LogError($"Verification failed. Error: {request.error}, Response Code: {request.responseCode}, Response Body: {request.downloadHandler.text}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Exception occurred: {ex.Message}");
                return null;
            }
        }
    }

    //CONVER
    public static async Task<string> ContinueVerifyProfileAsync(string emailCode, string email)
    {
        var url = "https://localhost:7193/api/regverlog/verify";
        var payload = new
        {
            EmailCode = emailCode,
            Email = email
        };

        string jsonPayload = JsonConvert.SerializeObject(payload);
        Debug.Log($"Serialized JSON payload: {jsonPayload}");

        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonPayload);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            try
            {
                var operation = request.SendWebRequest();
                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("Verefication successful!");
                    return request.downloadHandler.text;
                }
                else
                {
                    Debug.LogError($"Verefication failed. Error: {request.error}, Response Code: {request.responseCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Exception occurred: {ex.Message}");
                return null;
            }
        }
    }

    //RESSPASS
    public static async Task<string> ResetPasswordProfileAsync(string email)
    {
        var url = "https://localhost:7193/api/regverlog/resetpassword";

        var payload = new
        {
            Email = email
        };

        string jsonPayload = JsonConvert.SerializeObject(payload);
        Debug.Log($"Serialized JSON payload: {jsonPayload}");

        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonPayload);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            try
            {
                var operation = request.SendWebRequest();
                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result == UnityWebRequest.Result.Success)
                {
                    PlayerPrefs.SetString("Email", email);
                    Debug.Log("Ver code to reset send!");
                    return request.downloadHandler.text;
                }
                else
                {
                    Debug.LogError($"Reset rassword failed. Error: {request.error}, Response Code: {request.responseCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Exception occurred: {ex.Message}");
                return null;
            }
        }
    }

    //VERRESSPASS
    public static async Task<string> VerifyResetPasswordProfileAsync(string passwordresetcode, string newpassword)
    {
        string email = PlayerPrefs.GetString("Email");

        var url = "https://localhost:7193/api/regverlog/verifyresetpassword";

        var payload = new
        {
            Email = email,
            PasswordResetCode = passwordresetcode,
            NewPassword = newpassword
        };

        string jsonPayload = JsonConvert.SerializeObject(payload);
        Debug.Log($"Serialized JSON payload: {jsonPayload}");

        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonPayload);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            try
            {
                var operation = request.SendWebRequest();
                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("Reset rassword successful!");
                    return request.downloadHandler.text;
                }
                else
                {
                    Debug.LogError($"Reset rassword failed. Error: {request.error}, Response Code: {request.responseCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Exception occurred: {ex.Message}");
                return null;
            }
        }
    }

    //LOG
    public static async Task<string> LoginProfileAsync(string email, string password)
    {
        var url = "https://localhost:7193/api/regverlog/login";

        var payload = new
        {
            Email = email,
            Password = password
        };

        string jsonPayload = JsonConvert.SerializeObject(payload);
        Debug.Log($"Serialized JSON payload: {jsonPayload}");

        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonPayload);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            try
            {
                var operation = request.SendWebRequest();
                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("Login successful!");

                    Debug.Log($"Server response: {request.downloadHandler.text}");

                    try
                    {
                        var loginResponse = JsonConvert.DeserializeObject<PlayerLoginResponseDTO>(request.downloadHandler.text);


                        if (loginResponse == null)
                        {
                            Debug.LogError("Failed to deserialize user data: received null.");
                            return null;
                        }

                        PlayerData.Instance.SetUserData(
                            loginResponse.PlayerProfile.Nickname,
                            loginResponse.PlayerProfile.Level,
                            loginResponse.PlayerProfile.Gold,
                            loginResponse.PlayerProfile.Experience,
                            loginResponse.PlayerProfile.AvatarPath,
                            loginResponse.PlayerProfile.BattlesPlayed);

                        PlayerData.Instance.IsLoggedIn = true;

                        AuthManager.Instance.SetJwtToken(
                            loginResponse.AuthPlayerProfile.AccessToken,
                            loginResponse.AuthPlayerProfile.RefreshToken,
                            loginResponse.AuthPlayerProfile.RefreshTokenExpiryTime);

                        await LoadBoostersAsync();

                        await LoadCardsAsync();

                        await LoadDecksAsync();

                        return request.downloadHandler.text;
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError($"Deserialization error: {ex.Message}");
                        return null;
                    }
                }
                else
                {
                    Debug.LogError($"Login failed. Error: {request.error}, Response Code: {request.responseCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Exception occurred: {ex.Message}");
                return null;
            }
        }
    }

    //CARDSLOAD
    public static async Task LoadCardsAsync()
    {
        var url = $"https://localhost:7193/api/card/getallcards";

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("Content-Type", "application/json");

            try
            {
                request.SetRequestHeader("Authorization", $"Bearer {AuthManager.Instance.AccessToken}");

                var operation = request.SendWebRequest();

                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("Card data loaded successfully!");

                    Debug.Log($"Response: {request.downloadHandler.text}");

                    var cards = JsonConvert.DeserializeObject<List<CardLoadDTO>>(request.downloadHandler.text);

                    if (cards == null)
                    {
                        Debug.LogError("Failed to deserialize cards: received null.");
                        return;
                    }

                    Debug.Log($"From DB cards: {cards.Count}");

                    if (PlayerData.Instance.IsLoggedIn) 
                    {
                        PlayerData.Instance.SetUserCardData(cards, false);
                    }                    
                }
                else
                {
                    Debug.LogError($"Failed to load cards. Error: {request.error}, Response Code: {request.responseCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Exception occurred: {ex.Message}");
            }
        }
    }

    //ADDCARDS
    public static async Task AddCardsAsync(List<CardUploadDTO> cardRequests)
    {
        var url = "https://localhost:7193/api/card/addcards";
        var httpClient = new HttpClient();
        string json = JsonConvert.SerializeObject(cardRequests);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        httpClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", AuthManager.Instance.AccessToken);

        try
        {
            var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                Debug.Log("Cards added successfully!");
            }
            else
            {
                Debug.LogError($"Failed to add cards: {await response.Content.ReadAsStringAsync()}");
            }
        }
        catch (HttpRequestException e)
        {
            Debug.LogError($"Request error: {e.Message}");
        }
    }

    //BOOSTERLOAD
    public static async Task LoadBoostersAsync()
    {
        var url = $"https://localhost:7193/api/booster/getallboosters";

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("Content-Type", "application/json");

            try
            {
                request.SetRequestHeader("Authorization", $"Bearer {AuthManager.Instance.AccessToken}");

                var operation = request.SendWebRequest();
                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("Booster data loaded successfully!");

                    Debug.Log($"Response: {request.downloadHandler.text}");

                    var boosters = JsonConvert.DeserializeObject<List<BoosterLoadDTO>>(request.downloadHandler.text);

                    if (boosters == null)
                    {
                        Debug.LogError("Failed to deserialize boosters: received null.");
                        return;
                    }

                    Debug.Log($"From DB boosters: {boosters.Count}");

                    if (PlayerData.Instance.IsLoggedIn)
                    {
                        PlayerData.Instance.SetUserBoosterData(boosters, false);
                    }
                }
                else
                {
                    Debug.LogError($"Failed to load boosters. Error: {request.error}, Response Code: {request.responseCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Exception occurred: {ex.Message}");
            }
        }
    }

    //ADDBOOSTERS
    public static async Task AddBoostersAsync(List<BoosterUploadDTO> boosterRequests)
    {
        var url = "https://localhost:7193/api/booster/addboosters";
        var httpClient = new HttpClient();
        string json = JsonConvert.SerializeObject(boosterRequests);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        httpClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", AuthManager.Instance.AccessToken);

        try
        {
            var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                Debug.Log("Boosters added successfully!");
            }
            else
            {
                Debug.LogError($"Failed to add boosters: {await response.Content.ReadAsStringAsync()}");
            }
        }
        catch (HttpRequestException e)
        {
            Debug.LogError($"Request error: {e.Message}");
        }
    }

    //REMOVEBOOSTERS
    public static async Task RemoveBoostersAsync(List<BoosterUploadDTO> boosterRequests)
    {
        var url = "https://localhost:7193/api/booster/removeboosters";
        var httpClient = new HttpClient();
        string json = JsonConvert.SerializeObject(boosterRequests);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        httpClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", AuthManager.Instance.AccessToken);

        try
        {
            var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                Debug.Log("Boosters removed successfully!");
            }
            else
            {
                Debug.LogError($"Failed to remove boosters: {await response.Content.ReadAsStringAsync()}");
            }
        }
        catch (HttpRequestException e)
        {
            Debug.LogError($"Request error: {e.Message}");
        }
    }

    //GETDECK not used/tested yet
    public static async Task<DeckLoadDTO> GetDeckAsync(int deckId)
    {
        var url = $"https://localhost:7193/api/deck/getdeck/{deckId}";

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", $"Bearer {AuthManager.Instance.AccessToken}");

            try
            {
                var operation = request.SendWebRequest();
                while (!operation.isDone) await Task.Yield();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    var deck = JsonConvert.DeserializeObject<DeckLoadDTO>(request.downloadHandler.text);
                    return deck;
                }
                else
                {
                    Debug.LogError($"Failed to load deck. Error: {request.error}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Exception occurred: {ex.Message}");
                return null;
            }
        }
    }

    //DECKSLOAD
    public static async Task LoadDecksAsync()
    {
        var url = $"https://localhost:7193/api/deck/getalldecks";

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("Content-Type", "application/json");

            try
            {
                request.SetRequestHeader("Authorization", $"Bearer {AuthManager.Instance.AccessToken}");

                var operation = request.SendWebRequest();

                while (!operation.isDone)
                {
                    await Task.Yield();
                }

                if (request.result == UnityWebRequest.Result.Success)
                {
                    Debug.Log("Deck data loaded successfully!");

                    Debug.Log($"Response: {request.downloadHandler.text}");

                    var decks = JsonConvert.DeserializeObject<List<DeckLoadDTO>>(request.downloadHandler.text);

                    if (decks == null)
                    {
                        Debug.LogError("Failed to deserialize decks: received null.");
                        return;
                    }

                    Debug.Log($"From DB cards: {decks.Count}");

                    if (PlayerData.Instance.IsLoggedIn)
                    {
                        PlayerData.Instance.SetUserDeckData(decks);
                    }
                }
                else
                {
                    Debug.LogError($"Failed to load decks. Error: {request.error}, Response Code: {request.responseCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Exception occurred: {ex.Message}");
            }
        }
    }

    //ADDORUPDATEDECKS
    public static async Task AddOrUpdateDecksAsync(List<DeckLoadDTO> deckRequests)
    {
        var url = "https://localhost:7193/api/deck/addorupdatedecks";
        var httpClient = new HttpClient();
        string json = JsonConvert.SerializeObject(deckRequests);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        httpClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", AuthManager.Instance.AccessToken);

        try
        {
            var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                Debug.Log("Deck added successfully!");
            }
            else
            {
                Debug.LogError($"Failed to add deck: {await response.Content.ReadAsStringAsync()}");
            }
        }
        catch (HttpRequestException e)
        {
            Debug.LogError($"Request error: {e.Message}");
        }
    }

    //REMOVEDECKS
    public static async Task RemoveDecksAsync(List<DeckRemoveDTO> deckRequests)
    {
        var url = "https://localhost:7193/api/deck/removedecks";
        var httpClient = new HttpClient();
        string json = JsonConvert.SerializeObject(deckRequests);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        httpClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", AuthManager.Instance.AccessToken);

        try
        {
            var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                Debug.Log("Deck removed successfully!");
            }
            else
            {
                Debug.LogError($"Failed to remove deck: {await response.Content.ReadAsStringAsync()}");
            }
        }
        catch (HttpRequestException e)
        {
            Debug.LogError($"Request error: {e.Message}");
        }
    }

    //REMOVEDECKCARD
    public static async Task RemoveCardFromDeckAsync(DeckCardRemoveRequest deckCardRequest) 
    {
        var url = "https://localhost:7193/api/deckcard/removedeckcard";
        var httpClient = new HttpClient();
        string json = JsonConvert.SerializeObject(deckCardRequest);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        httpClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", AuthManager.Instance.AccessToken);

        try
        {
            var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                Debug.Log("DeckCard removed successfully!");
            }
            else
            {
                Debug.LogError($"Failed to remove DeckCard: {await response.Content.ReadAsStringAsync()}");
            }
        }
        catch (HttpRequestException e)
        {
            Debug.LogError($"Request error: {e.Message}");
        }
    }

    //ADDDECKCARD
    public static async Task AddCardToDeckAsync(DeckCardRequest deckCardRequest)
    {
        var url = "https://localhost:7193/api/deckcard/adddeckcard";
        var httpClient = new HttpClient();
        string json = JsonConvert.SerializeObject(deckCardRequest);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        httpClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", AuthManager.Instance.AccessToken);

        try
        {
            var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                Debug.Log("DeckCard added successfully!");
            }
            else
            {
                Debug.LogError($"Failed to add DeckCard: {await response.Content.ReadAsStringAsync()}");
            }
        }
        catch (HttpRequestException e)
        {
            Debug.LogError($"Request error: {e.Message}");
        }
    }

    public static async Task UpdateDeckCardsOrderAsync(List<DeckCardOrderRequest> deckCardOrderRequest)
    {
        var url = "https://localhost:7193/api/deckcard/updatedeckcardsorder";
        var httpClient = new HttpClient();    

        string json = JsonConvert.SerializeObject(deckCardOrderRequest);

        Debug.Log($"Request JSON: {json}");

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        httpClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", AuthManager.Instance.AccessToken);

        try
        {
            Debug.Log("Sending request to server...");

            var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                Debug.Log("DeckCard order updated successfully!");
                var responseContent = await response.Content.ReadAsStringAsync();
                Debug.Log($"Server response: {responseContent}");
            }
            else
            {
                Debug.LogError($"Failed to update order DeckCard: {await response.Content.ReadAsStringAsync()}");
            }
        }
        catch (HttpRequestException e)
        {
            Debug.LogError($"Request error: {e.Message}");
        }
    }

    public static async Task UpdateDecksOrderAsync(List<DeckOrderRequest> deckOrderRequest)
    {
        var url = "https://localhost:7193/api/deck/updatedecksorder";
        var httpClient = new HttpClient();

        string json = JsonConvert.SerializeObject(deckOrderRequest);

        Debug.Log($"Request JSON: {json}");

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        httpClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", AuthManager.Instance.AccessToken);

        try
        {
            Debug.Log("Sending request to server...");

            var response = await httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                Debug.Log("Deck order updated successfully!");
                var responseContent = await response.Content.ReadAsStringAsync();
                Debug.Log($"Server response: {responseContent}");
            }
            else
            {
                Debug.LogError($"Failed to update order Deck: {await response.Content.ReadAsStringAsync()}");
            }
        }
        catch (HttpRequestException e)
        {
            Debug.LogError($"Request error: {e.Message}");
        }
    }
}
