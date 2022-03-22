using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    private RawImage image;
    [SerializeField] private string imageURL;

    private void OnEnable()
    {
        image = GetComponent<RawImage>();
        if (image == null)
        {
            Debug.Log(gameObject.name);
        }
        if (image.texture == null)
        {
            StartCoroutine(GimmeDatTexture(imageURL));
        }


    }
    private IEnumerator GimmeDatTexture(string logoLink)
    {

        if (logoLink != "")
        {
            yield return new WaitForEndOfFrame();
            Debug.Log(Screen.width + " " + Screen.height);
            WWW www = new WWW(logoLink);

            Debug.Log("Downloading " + logoLink);
            yield return www;
            Debug.Log("image loaded");
            image.texture = www.texture;
        }
        else
        {
            Debug.Log("No image provided, using default");
        }
    }

    public void UpdateLink(string URL)
    {
        imageURL = URL;
        StartCoroutine(GimmeDatTexture(imageURL));

    }

    private void OnDisable()
    {
        image.texture = null;
        imageURL = "";
    }
}
