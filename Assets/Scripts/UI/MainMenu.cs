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
    [SerializeField] 
    private SaveController saveController;
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button levelsButton;
    [SerializeField]
    private Button returnButton;
    [SerializeField]
    private Button aboutButton;
    [SerializeField] 
    private GameObject mainPanel;
    [SerializeField] 
    private GameObject levelPanel;
    [SerializeField] 
    private GameObject aboutPanel;
    
    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        levelsButton.onClick.AddListener(OpenLevelMenu);
        returnButton.onClick.AddListener(ReturnToMain);
        aboutButton.onClick.AddListener(OpenAboutMenu);
    }

    private void StartGame()
    {   
        levelManager.StartLastOpenedLevel();
    }

    private void OpenAboutMenu()
    {
        mainPanel.SetActive(false);
        levelPanel.SetActive(false);
        aboutPanel.SetActive(true);

    }
    
    private void OpenLevelMenu()
    {
        mainPanel.SetActive(false);
        levelPanel.SetActive(true);
        aboutPanel.SetActive(false);
        var openedLevelsCount = saveController.ReturnOpenedLevelsCount;
        Debug.Log(openedLevelsCount);
        for (int i = 0; i < levelPanel.transform.childCount; i++)
        {
            if (i <= openedLevelsCount-1)
            {
                levelPanel.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                Debug.Log(levelPanel.transform.GetChild(i).gameObject.name);
                levelPanel.transform.GetChild(i).gameObject.SetActive(false);
            }
            if (i == levelPanel.transform.childCount-1) 
                levelPanel.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void ReturnToMain()
    {
        aboutPanel.SetActive(false);
        mainPanel.SetActive(true);
        levelPanel.SetActive(false);
    }
}
