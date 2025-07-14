using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCollection : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

}

