using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour
{
    [SerializeField] 
    private SaveController saveController;
    [SerializeField] 
    private LoadLevels sceneController;
    [SerializeField]
    private Transform startPlayerPos;
    [SerializeField] 
    private Button restartButtonStatic;
    [SerializeField] 
    private Button restartButtonLoose;
    [SerializeField] 
    private Button nextLevel;
    [SerializeField] 
    private Button returnToMenuLose;
    [SerializeField] 
    private Button returnToMenuWin;
    [SerializeField] 
    private TMP_Text timerText;
    [SerializeField] 
    private GameObject looseWindow;
    [SerializeField] 
    private GameObject winWindow;
    [SerializeField] 
    private PlayerController playerController;
    private readonly float _timerTime = 10f;
    private Vector3 _positionBackup;
    private Vector3 _anglesBackup;

    private void Start()
    {
        _positionBackup = startPlayerPos.position;
        _anglesBackup = startPlayerPos.eulerAngles;
        looseWindow.SetActive(false);
        winWindow.SetActive(false);
        timerText.text = $"00:{10}";
        StartGame();
        restartButtonStatic.onClick.AddListener(RestartGame);
        restartButtonLoose.onClick.AddListener(RestartGame);
        nextLevel.onClick.AddListener(NextLevel);
        returnToMenuWin.onClick.AddListener(ReturnToMenu);
        returnToMenuLose.onClick.AddListener(ReturnToMenu);
    }
    
    
    public void StartGame()
    {
        playerController.EnableInput();
        winWindow.SetActive(false);
        looseWindow.SetActive(false);
        startPlayerPos.position = _positionBackup;
        startPlayerPos.eulerAngles = _anglesBackup;
        StartCoroutine(Timer());
    }

    public void RestartGame()
    {
        StopAllCoroutines();
        StartGame();
    }
    
    public void EndGame()
    {
        playerController.DisableInput();
        StopAllCoroutines();
    }

    public void Win()
    {
        saveController.OpenNextLevel();
        EndGame();
        winWindow.SetActive(true);
    }
    
    public void Loose()
    {
        playerController.Die();
        EndGame();
        looseWindow.SetActive(true);
    }
    
    public void ReturnToMenu()
    {
        StopAllCoroutines();
        sceneController.ReturnToMenu();
    }
    
    public void NextLevel()
    {
        StopAllCoroutines();
        sceneController.StartLastOpenedLevel();
    }
    private IEnumerator Timer()
    {
        var currentTime = 0;
        while (currentTime < _timerTime)
        {
            timerText.text = $"00:{10 - currentTime}";
            currentTime += 1;
            yield return new WaitForSeconds(1);
        }
        timerText.text = "00:00";
        Loose();
    }
    
   
}
