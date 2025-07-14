using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private MainLogin mainLogin;

    public void OnLoginButtonClick()
    {
        LoginButton();
    }

    public async void LoginButton()
    {
        LoadStageManager.Instance.Show();

        string email = emailInputField.text;
        string password = passwordInputField.text;

        if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
        {
            LogManager.Instance.Log("Please fill in all fields!");
            Debug.LogError("Please fill in all fields!");
            return;
        }

        string response = await ApiClient.LoginProfileAsync(email, password);

        if (!string.IsNullOrEmpty(response))
        {
            LogManager.Instance.Log("Login successful!");
            mainLogin.OkToProfile();
        }
        else
        {
            LogManager.Instance.Log("Login failed! \nIs the email/password correct? \nVerification complete?");
            Debug.LogError("Login failed." + response);
        }

        LoadStageManager.Instance.Hide();
    }
}
