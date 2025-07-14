using TMPro;
using UnityEngine;

public class VerifyPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField emailcodeInputField;
    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private MainLogin mainLogin;

    public async void OnVerifyButtonClicked()
    {
        string emailCode = emailcodeInputField.text;

        if (string.IsNullOrWhiteSpace(emailCode))
        {
            LogManager.Instance.Log("Please enter the code!");
            Debug.LogError("Please enter the code!");
            return;
        }

        string response = await ApiClient.VerifyProfileAsync(emailCode);
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
        