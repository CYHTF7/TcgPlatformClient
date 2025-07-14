using Cards;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Boosters;

public class MainStore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;

    private void Start()
    {
        if (PlayerData.Instance == null)
        {
            Debug.LogError("Error! PlayerData.Instance is null!");
            return;
        }

        UpdateSceneUI();
    }

    //SCENES
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToUnpackBooster()
    {
        SceneManager.LoadScene("MainUnpackBooster");
    }

    //
    public void UpdateSceneUI()
    {
        goldText.text = $"Gold: {PlayerData.Instance.Gold}";
    }

}
