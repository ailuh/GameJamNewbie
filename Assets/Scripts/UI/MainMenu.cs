using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] 
    private LoadLevels levelManager;
    [FormerlySerializedAs("saveManager")] [SerializeField] 
    private SaveController saveController;
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button levelsButton;
    [SerializeField]
    private Button aboutButton;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {   
        levelManager.StartLastOpenedLevel();
    }
}
