using TMPro;
using UnityEngine;

public class VerifyResetPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField passwordresetcodeInputField;
    [SerializeField] private TMP_InputField newpasswordInputField;
    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private MainLogin mainLogin;

    public async void OnVerifyResetButtonClicked()
    {
        string passwordresetcode = passwordresetcodeInputField.text;
        string newpassword = newpasswordInputField.text;

        if (string.IsNullOrWhiteSpace(newpassword) || string.IsNullOrWhiteSpace(passwordresetcode))
        {
            LogManager.Instance.Log("Please fill all fields!");
            Debug.LogError("Please fill all fields!");
            return;
        }

        string response = await ApiClient.VerifyResetPasswordProfileAsync(passwordresetcode, newpassword);
        if (!string.IsNullOrEmpty(response))
        {
            LogManager.Instance.Log("Verefi code send!");
            mainLogin.ShowLoginPanel();
            Debug.Log("Verefi code send: " + response);
        }
        else
        {
            LogManager.Instance.Log("Reset failed!");
            Debug.LogError("Reset failed." + response);
        }
    }
}
