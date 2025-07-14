using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResetPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private MainLogin mainLogin;

    public async void OnResetButtonClicked()
    {
        string email = emailInputField.text;

        if (string.IsNullOrWhiteSpace(email))
        {
            LogManager.Instance.Log("Please fill all fields!");
            Debug.LogError("Please fill all fields!");
            return;
        }

        string response = await ApiClient.ResetPasswordProfileAsync(email);
        if (!string.IsNullOrEmpty(response))
        {
            LogManager.Instance.Log("Verefi code send!");
            mainLogin.ShowVerifyResetPanel();
            Debug.Log("Verefi code send: " + response);
        }
        else
        {
            LogManager.Instance.Log("Reset failed!");
            Debug.LogError("Reset failed." + response);
        }
    }
}
