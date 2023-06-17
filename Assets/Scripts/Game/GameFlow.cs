using System.Collections;
using SaveData;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
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
        private bool _isEnded;

        private void Start()
        {
            _isEnded = false;
            _positionBackup = startPlayerPos.position;
            _anglesBackup = startPlayerPos.eulerAngles;
            looseWindow.SetActive(false);
            winWindow.SetActive(false);
            timerText.text = "00:10";
            StartGame();
            restartButtonStatic.onClick.AddListener(RestartGame);
            restartButtonLoose.onClick.AddListener(RestartGame);
            if (nextLevel != null)
                nextLevel.onClick.AddListener(NextLevel);
            returnToMenuWin.onClick.AddListener(ReturnToMenu);
            returnToMenuLose.onClick.AddListener(ReturnToMenu);
        }


        private void StartGame()
        {
            _isEnded = false;
            playerController.EnableInput();
            winWindow.SetActive(false);
            looseWindow.SetActive(false);
            startPlayerPos.position = _positionBackup;
            startPlayerPos.eulerAngles = _anglesBackup;
            StartCoroutine(Timer());
        }

        private void RestartGame()
        {
            StopAllCoroutines();
            StartGame();
        }

        private void EndGame()
        {
            _isEnded = true;
            playerController.DisableInput();
            StopAllCoroutines();
        }

        public void Win()
        {
            if (!_isEnded)
            {
                saveController.OpenNextLevel();
                EndGame();
                winWindow.SetActive(true);
            }
        }
    
        public void Loose()
        {
            if (!_isEnded)
            {
                playerController.Die();
                EndGame();
                looseWindow.SetActive(true);
            }
        }

        private void ReturnToMenu()
        {
            StopAllCoroutines();
            sceneController.ReturnToMenu();
        }

        private void NextLevel()
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
}
