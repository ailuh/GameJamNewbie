using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour
{
    private float _timerTime = 10f;
    [SerializeField] private Button restartButton;
    [SerializeField] private TMP_Text timerText;

    private void Start()
    {
        timerText.text = $"00:{10}";
        StartGame();
        restartButton.onClick.AddListener(RestartGame);
    }

    public void StartGame()
    {
        StartCoroutine(Timer());
    }

    public void RestartGame()
    {
        StopAllCoroutines();
        StartCoroutine(Timer());
    }
    
    public void EndGame()
    {
        StopAllCoroutines();
    }
    
    private IEnumerator Timer()
    {
        Debug.Log("TimerStarted");
        var currentTime = 0;
        while (currentTime < _timerTime)
        {
            currentTime += 1;
            timerText.text = $"00:{10 - currentTime}";
            yield return new WaitForSeconds(1);
        }

        timerText.text = "00:00";

    }
}
