using SaveData;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
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
        private GameObject levelPanelMain;
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
            levelPanelMain.SetActive(false);
            mainPanel.SetActive(false);
            aboutPanel.SetActive(true);

        }
    
        private void OpenLevelMenu()
        {
            mainPanel.SetActive(false);
            levelPanelMain.SetActive(true);
            aboutPanel.SetActive(false);
            var openedLevelsCount = saveController.ReturnOpenedLevelsCount;
            for (int i = 0; i < levelPanel.transform.childCount; i++)
            {
                if (i <= openedLevelsCount-1)
                {
                    levelPanel.transform.GetChild(i).gameObject.SetActive(true);
                }
                else
                {
                    levelPanel.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }

        public void ReturnToMain()
        {
            aboutPanel.SetActive(false);
            mainPanel.SetActive(true);
            levelPanelMain.SetActive(false);
        }
    }
}
