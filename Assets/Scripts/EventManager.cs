using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    [Header("User Registration")]
    public TMP_InputField username;
    public TMP_InputField email, password,confirmPassword;
    public Text resultText;

    [Header("User Login")]
    public TMP_InputField loginEmail;
    public TMP_InputField loginPassword;
    public Text loginResult;

    [DllImport("__Internal")]
    private static extern void CreateUser(string username, string email, string password, string callback, string fallback);
    [DllImport("__Internal")]
    private static extern void LoginUser(string email, string password, string callback, string fallback);
    [DllImport("__Internal")]
    private static extern void SignOut(string callback, string fallback);

    [DllImport("__Internal")]
    private static extern void UploadProfilePic(string callback, string fallback);

    [DllImport("__Internal")]
    private static extern void GetProfilePic(string callback, string fallback);

    private void Awake()
    {
        instance = this;
    }
    public void RegisterUser()
    {
        if(username.text == "")
        {
            resultText.color = Color.red;
            resultText.text = "username required";
        }
        else if (email.text == "")
        {
            resultText.color = Color.red;
            resultText.text = "email required";
        }
        else if(password.text != confirmPassword.text)
        {
            resultText.color = Color.red;
            resultText.text = "password confirm must match";
        }
        else
        {
            CreateUser(username.text, email.text, password.text, "OnRegisterSuccess", "OnRequestFailed");
            
        }
    }
    

    private void OnRegisterSuccess(string data)
    {
        resultText.color = Color.green;
        resultText.text = data;
        username.text = "";
        email.text = "";
        password.text = "";
        confirmPassword.text = "";
    }
    private void OnRequestFailed(string error)
    {
        resultText.color = Color.red;
        resultText.text = error;
    }

    public void LoginUser()
    {
        if (loginEmail.text == "")
        {
            loginResult.color = Color.red;
            loginResult.text = "email required";
        }
        else if (loginPassword.text == "")
        {
            resultText.color = Color.red;
            resultText.text = "password incorrect";
        }
        else
        {
            LoginUser(loginEmail.text, loginPassword.text, "OnLoginSuccess", "OnLoginFailed");
        }
    }

    private void OnLoginSuccess(string data)
    {
        UIManager.instance.ShowProfile(data);
        loginResult.color = Color.green;
        loginResult.text = "login success";
        loginEmail.text = "";
        loginPassword.text = "";
    }

    private void OnLoginFailed(string error)
    {
        loginResult.color = Color.red;
        loginResult.text = error;
    }

    public void UserSignOut()
    {
        SignOut("OnSignOutSuccess", "OnSignOutFailed");
    }

    private void OnSignOutSuccess(string data)
    {
        UIManager.instance.ShowLogin();
        loginResult.color = Color.green;
        loginResult.text = "signed out user";
        loginEmail.text = "";
        loginPassword.text = "";
    }

    private void OnSignOutFailed(string error)
    {
        loginResult.color = Color.red;
        loginResult.text = error;
    }

    public void UploadProfilePicture()
    {
        UploadProfilePic("OnProfileUploadSuccess", "OnProfileUploadFailed");
    }
    private void OnProfileUploadSuccess(string data)
    {
        UIManager.instance.UpdateProfileImage(data);
    }

    private void OnProfileUploadFailed(string error)
    {
        UIManager.instance.profileStatus.text = error;
    }

    public void GetProfilePicture()
    {
        GetProfilePic("OnGetProfilePicSuccess", "OnGetProfilePicFailed");
    }
    private void OnGetProfilePicSuccess(string data)
    {
        UIManager.instance.UpdateProfileImage(data);
    }

    private void OnGetProfilePicFailed(string error)
    {
        UIManager.instance.profileStatus.text = error;

    }

}
