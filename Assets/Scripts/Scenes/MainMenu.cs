using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        if (PlayerData.Instance.IsLoggedIn == false) 
        {
            LogManager.Instance.Log("Please go to Profile and login!");
        }       
    }

    public void OpenCollection()
    {
        SceneManager.LoadScene("MainCollection");
    }

    public void OpenStore()
    {
        SceneManager.LoadScene("MainStore");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Done");
    }

    public void OpenLogin() 
    {
        if (PlayerData.Instance.IsLoggedIn == true)
        {
            SceneManager.LoadScene("MainProfile");
        }
        else
        {
            SceneManager.LoadScene("MainLogin");
        }      
    }
}
