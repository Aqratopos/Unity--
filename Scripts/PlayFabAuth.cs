using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabAuth : MonoBehaviour
{
    public InputField emailInput;
    public InputField passwordInput;
    public InputField usernameInput;
    public Text debugText; // Reference to the Text component on your Canvas
    public GameObject Demo;
    
    void Start()
    {
        Demo.SetActive(false);
    }
    
    // 注册新用户
    public void Register()
    {
        if (string.IsNullOrEmpty(emailInput.text) || string.IsNullOrEmpty(passwordInput.text))
        {
            debugText.text ="电子邮件地址和密码不能为空！";
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {
            Username = usernameInput.text,
            Email = emailInput.text,
            Password = passwordInput.text
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnFail);
    }

    // 登录已有用户
    public void Login()
    {
        if (string.IsNullOrEmpty(emailInput.text) || string.IsNullOrEmpty(passwordInput.text))
        {
            debugText.text ="电子邮件地址和密码不能为空！";
            return;
        }

        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnFail);
    }

    // 注册成功的回调
    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        DisplayDebugMessage("注册成功！");
    }

    // 登录成功的回调
    private void OnLoginSuccess(LoginResult result)
    {
        DisplayDebugMessage("登录成功！");
        Demo.SetActive(true);
        gameObject.SetActive(false);
    }

    // 请求失败的回调
    private void OnFail(PlayFabError error)
    {
        DisplayDebugError(error.GenerateErrorReport());
    }

    // Display debug message on the Canvas Text
    private void DisplayDebugMessage(string message)
    {
        debugText.text = message;
    }

    // Display debug error on the Canvas Text
    private void DisplayDebugError(string error)
    {
        debugText.text = "错误： " + error;
    }
}