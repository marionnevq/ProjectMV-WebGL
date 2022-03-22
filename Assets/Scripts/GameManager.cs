using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Button startButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private GameObject ninja;
    [SerializeField] private TextMeshProUGUI timer;

    private float elapsedTime;


    private bool isPlaying;
    void Start()
    {
        isPlaying = false;
        elapsedTime = 0.0f;
        resetButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
    }
    public void Update()
    {
        if (isPlaying)
        {
            
            elapsedTime += Time.deltaTime;
            timer.text = elapsedTime.ToString("F2");
        }
    }

    public void EndGame()
    {
        isPlaying = false;
        resetButton.gameObject.SetActive(true);
        ninja.SetActive(false);
    }

    public void Reset()
    {
        background.color = Color.white;
        resetButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
        elapsedTime = 0.0f;
        timer.text = elapsedTime.ToString("F2");
        isPlaying = false;
    }
    public void StartGame()
    {
        background.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        isPlaying = true;
        timer.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        GenerateNinja();
    }

    void GenerateNinja()
    {
        Vector2 newLoc = new Vector2(Random.Range(-315.38f, 315.38f),Random.Range(-196.92f, 196.92f));
        ninja.GetComponent<RectTransform>().localPosition = newLoc;
        ninja.SetActive(true);
    }
}
