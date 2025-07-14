using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainLogin : MonoBehaviour
{

    public GameObject LoginPanel;
    public GameObject RegisterPanel;
    public GameObject VerifyPanel;
    public GameObject ContinueVerifyPanel;
    public GameObject ResetPanel;
    public GameObject ResetVerifyPanel;

    void Start()
    {
        ShowRegisterPanel();
    }

    public void ShowLoginPanel() 
    {
        LoginPanel.SetActive(true);
        RegisterPanel.SetActive(false);
        VerifyPanel.SetActive(false);
        ContinueVerifyPanel.SetActive(false);
        ResetPanel.SetActive(false);
        ResetVerifyPanel.SetActive(false);
    }

    public void ShowResetPanel()
    {
        ResetPanel.SetActive(true);
        LoginPanel.SetActive(false);
        RegisterPanel.SetActive(false);
        VerifyPanel.SetActive(false);
        ContinueVerifyPanel.SetActive(false);
        ResetVerifyPanel.SetActive(false);
    }

    public void ShowVerifyResetPanel()
    {
        ResetVerifyPanel.SetActive(true);
        ResetPanel.SetActive(false);
        LoginPanel.SetActive(false);
        RegisterPanel.SetActive(false);
        VerifyPanel.SetActive(false);
        ContinueVerifyPanel.SetActive(false);
    }

    public void ShowRegisterPanel()
    {
        RegisterPanel.SetActive(true);
        LoginPanel.SetActive(false);
        VerifyPanel.SetActive(false);
        ContinueVerifyPanel.SetActive(false);
        ResetPanel.SetActive(false);
        ResetVerifyPanel.SetActive(false);
    }

    public void ShowVerifyPanel()
    {
        VerifyPanel.SetActive(true);
        RegisterPanel.SetActive(false);
        LoginPanel.SetActive(false);
        ContinueVerifyPanel.SetActive(false);
        ResetPanel.SetActive(false);
        ResetVerifyPanel.SetActive(false);
    }

    public void ShowContinueVerifyPanel()
    {
        ContinueVerifyPanel.SetActive(true);
        VerifyPanel.SetActive(false);
        RegisterPanel.SetActive(false);
        LoginPanel.SetActive(false);
        ResetPanel.SetActive(false);
        ResetVerifyPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OkToProfile()
    {
        SceneManager.LoadScene("MainProfile");
    }
}
