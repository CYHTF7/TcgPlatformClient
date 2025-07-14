using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadStageManager : MonoBehaviour
{
    public static LoadStageManager Instance { get; private set; }

    private GameObject loadStageImage;

    private bool isActive;

    private void Awake()
    { 
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        FindLoadStageImageInScene();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindLoadStageImageInScene();
    }

    private void FindLoadStageImageInScene()
    {
        isActive = true;

        GameObject canvas = GameObject.FindGameObjectWithTag("LoadStageImage");

        if (canvas != null)
        {
            loadStageImage = canvas.transform.Find("LoadStageImage")?.gameObject;

            if (loadStageImage != null)
            {
                loadStageImage.transform.localRotation = Quaternion.identity;
                Hide();
                Debug.Log("Hided");
            }
            else
            {
                Debug.LogWarning("LoadStageImage (icon) not found inside Canvas!");
            }
        }
        else
        {
            Debug.LogWarning("Canvas with tag LoadStageImage not found!");
        }
    }

    public void Show()
    {
        if (isActive) return;

        if (loadStageImage == null)
        {
            FindLoadStageImageInScene();
        }

        if (loadStageImage != null)
        {
            loadStageImage.SetActive(true);
            isActive = true;
        }
    }

    public void Hide()
    {
        if (!isActive) return;

        if (loadStageImage != null)
        {
            loadStageImage.SetActive(false);
            isActive = false;
        }
    }


    void Update()
    {
        if (loadStageImage != null && loadStageImage.activeSelf)
        {
            loadStageImage.transform.Rotate(0, 0, -300 * Time.deltaTime);
        }
    }
}
