using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogManager : MonoBehaviour
{
    public static LogManager Instance { get; private set; }
    private TextMeshProUGUI logText;

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
        FindLogTextInScene();
    }

    private void FindLogTextInScene()
    {
        if (logText == null)
        {
            logText = GameObject.FindGameObjectWithTag("LogText")?.GetComponent<TextMeshProUGUI>();
        }

        if (logText == null)
        {
            Debug.LogWarning("LogManager not found!");
        }  
    }

    public void Log(string message)
    {
        if (logText == null)
        {
            FindLogTextInScene();
        }

        if (logText != null)
        {
            logText.text += message + "\n";
            StartCoroutine(RemoveMessageAfterDelay(message, 10f));
        }
        else
        {
            Debug.LogWarning("LogManager not found!");
        }
    }

    private IEnumerator RemoveMessageAfterDelay(string message, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (logText != null && logText.text.Contains(message))
        {
            logText.text = logText.text.Replace(message + "\n", "");
        }
    }
}

