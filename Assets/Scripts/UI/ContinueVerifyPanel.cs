using TMPro;
using UnityEngine;

public class ContinueVerifyPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField emailcodeInputField;
    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private MainLogin mainLogin;

    public async void OnContinueVerifyButtonClicked()
    {
        string email = emailInputField.text;
        string emailCode = emailcodeInputField.text;

        if (string.IsNullOrWhiteSpace(emailCode) || string.IsNullOrWhiteSpace(email))
        {
            LogManager.Instance.Log("Please fill in all fields!");
            Debug.LogError("Please fill in all fields!");
            return;
        }

        string response = await ApiClient.ContinueVerifyProfileAsync(emailCode, email);

        Debug.Log("Verification enter");

        if (!string.IsNullOrEmpty(response))
        {
            mainLogin.ShowLoginPanel();
            LogManager.Instance.Log("Verification successful, please login in your profile!");
            Debug.Log("Verification successful: " + response);
        }
        else
        {
            LogManager.Instance.Log("Verification failed! \nPlease double-check your code!");
            Debug.LogError("Verification failed." + response);
        }
    }
}
        