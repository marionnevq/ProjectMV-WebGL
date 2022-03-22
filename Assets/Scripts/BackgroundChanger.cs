using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour
{
    [SerializeField] private Image background;
    void Start()
    {
        background = GetComponent<Image>();
    }

    public void ChangeBG()
    {
        background.color =new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);   
    }
}
