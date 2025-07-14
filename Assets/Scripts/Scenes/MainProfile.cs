using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainProfile : MonoBehaviour

{
    [SerializeField] private TextMeshProUGUI nicknameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI experienceText;
    [SerializeField] private TextMeshProUGUI battlesPlayedText;

    private void Start()
    {
        if (PlayerData.Instance == null)
        {
            Debug.LogError("Error! PlayerData.Instance is null!");
            return;
        }

        UpdateProfileUI();
    }

    private void Awake()
    {
        UpdateProfileUI();
    }

    public void UpdateProfileUI()
    {
        nicknameText.text = $"{PlayerData.Instance.Nickname}";
        levelText.text = $"Level: {PlayerData.Instance.Level}";
        goldText.text = $"Gold: {PlayerData.Instance.Gold}";
        experienceText.text = $"XP: {PlayerData.Instance.Experience}";
        battlesPlayedText.text = $"Battles: {PlayerData.Instance.BattlesPlayed}";
    }

public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
