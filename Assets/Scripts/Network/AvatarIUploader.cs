using SFB;
using System.Collections;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AvatarUploader : MonoBehaviour
{
    public static Texture2D CachedAvatarTexture; 
    public Image avatarImage; 

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (avatarImage != null && CachedAvatarTexture != null)
        {
            ApplyAvatarToImage(avatarImage);
        }
        else
        {
            GetAvatarAsync();
        }
    }

    public void ApplyAvatarToImage(Image targetImage)
    {
        if (CachedAvatarTexture != null && targetImage != null)
        {
            Sprite avatarSprite = Sprite.Create(CachedAvatarTexture, new Rect(0, 0, CachedAvatarTexture.width, CachedAvatarTexture.height), new Vector2(0.5f, 0.5f));
            targetImage.sprite = avatarSprite;
        }
    }

    public void OnSelectAndUploadAvatarClick()
    {
        SelectAndUploadAvatar();
    }

    public async void SelectAndUploadAvatar() 
    {
        LoadStageManager.Instance.Show();

        var paths = StandaloneFileBrowser.OpenFilePanel("Select Avatar", "", "jpg", false);
        if (paths.Length > 0 && !string.IsNullOrEmpty(paths[0]))
        {
            await UploadImageAsync(paths[0]); 
        }

        LoadStageManager.Instance.Hide();
    }

    public async Task UploadImageAsync(string filePath)
    {
        //if (PlayerData.Instance == null || string.IsNullOrEmpty(PlayerData.Instance.Id.ToString()))
        if (PlayerData.Instance == null)
        {
            Debug.LogError("Error: PlayerData.Instance.Id not set!");
            return;
        }

        byte[] fileData = File.ReadAllBytes(filePath);
        WWWForm form = new WWWForm();
        form.AddBinaryData("file", fileData, Path.GetFileName(filePath), "image/jpeg");
        //form.AddField("userId", PlayerData.Instance.Id);

        using (UnityWebRequest request = UnityWebRequest.Post("https://localhost:7193/api/avatar/uploadavatar", form))
        {
            request.SetRequestHeader("Authorization", $"Bearer {AuthManager.Instance.AccessToken}");

            var operation = request.SendWebRequest();

            while (!operation.isDone)
                await Task.Yield(); 

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Avatar uploaded!");
                await GetAvatarAsync(); 
            }
            else
            {
                Debug.LogError($"Upload error: {request.responseCode} - {request.downloadHandler.text}");
            }
        }
    }

    public async Task GetAvatarAsync()
    {
        //if (PlayerData.Instance == null || string.IsNullOrEmpty(PlayerData.Instance.Id.ToString()))
        if (PlayerData.Instance == null)
        {
            Debug.LogError("Error: PlayerData.Instance.Id not set!");
            return;
        }

        using (UnityWebRequest request = UnityWebRequest.Get($"https://localhost:7193/api/avatar/getavatar"))
        {
            LoadStageManager.Instance.Show();

            request.SetRequestHeader("Authorization", $"Bearer {AuthManager.Instance.AccessToken}");

            Debug.Log($"Access Token: {AuthManager.Instance.AccessToken}");

            var operation = request.SendWebRequest();

            while (!operation.isDone)
                await Task.Yield();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(request.downloadHandler.data);
                CachedAvatarTexture = texture;

                ApplyAvatarToImage(avatarImage);
                Debug.Log("Avatar loaded in Unity!");
            }

            LoadStageManager.Instance.Hide();
        }
    }
}
