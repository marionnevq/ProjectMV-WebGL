using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject registerPanel, loginPanel, profilePanel;

    [SerializeField] private Text profileText;

    public Text profileStatus;

    [SerializeField] private ImageLoader profileImage;


    private void Awake()
    {
        instance = this;
    }

    public void ShowRegister()
    {
        registerPanel.gameObject.SetActive(true);
        HideLogin();
        HideProfile();
    }

    public void HideRegister()
    {
        registerPanel.gameObject.SetActive(false);
    }
    public void ShowLogin()
    {
        loginPanel.gameObject.SetActive(true);
        HideRegister();
        HideProfile();
    }

    public void HideLogin()
    {
        loginPanel.gameObject.SetActive(false);
    }

    public void ShowProfile(string data)
    {
        string[] message = data.Split(':');

        profilePanel.SetActive(true);

        profileText.text = "Welcome, " + message[0] + "!";
        if (message[1] == "true")
        {
            profileStatus.color = Color.green;
            profileStatus.text = "Your email is verified";
        }else if(message[1] == "false")
        {
            profileStatus.color = Color.red;
            profileStatus.text = "Your email is not verified";

        }
        profileText.color = Color.green;
        HideLogin();
        HideRegister();
        EventManager.instance.GetProfilePicture();
    }

    public void HideProfile()
    {
        profilePanel.SetActive(false);
    }

    public void UpdateProfileImage(string URL)
    {
        profileImage.UpdateLink(URL);
    }
}
