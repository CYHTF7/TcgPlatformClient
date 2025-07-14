using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUnpackBooster : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI booster11Text;

    void Start()
    {
        UpdateSceneUI();
    }

    private void OnEnable()
    {
        UpdateSceneUI();
    }

    public void UpdateSceneUI()
    {
        if (PlayerData.Instance.boosterQuantities != null && PlayerData.Instance.boosterQuantities.TryGetValue(11, out int count))
        {
            booster11Text.text = $"Heroes of Azeroth: {count}";
        }
        else
        {
            booster11Text.text = "Heroes of Azeroth: 0";
        }
    }

    public void BackToStore()
    {
        SceneManager.LoadScene("MainStore");
    }
}
