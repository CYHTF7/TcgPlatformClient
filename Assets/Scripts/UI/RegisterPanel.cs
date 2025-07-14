using TMPro;
using UnityEngine;

public class RegistrationPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private MainLogin mainLogin;

    public async void OnRegisterButtonClicked()
    {
        string nickname = usernameInputField.text;
        string email = emailInputField.text;
        string password = passwordInputField.text;

        if (string.IsNullOrWhiteSpace(nickname) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            LogManager.Instance.Log("Please fill in all fields!");
            Debug.LogError("Please fill in all fields!");
            return;
        }

        string response = await ApiClient.RegisterProfileAsync(nickname, email, password);
        if (!string.IsNullOrEmpty(response))
        {
            mainLogin.ShowVerifyPanel();
            LogManager.Instance.Log("Registration successful, please verify your profile!");
            Debug.Log("Registration successful: " + response);
        }
        else
        {
            LogManager.Instance.Log("Registration failed! \nEmail can be used or server has reached limit of sending verification codes. \nPlease try again later!");
            Debug.LogError("Registration failed." + response);
        }
    }
}
