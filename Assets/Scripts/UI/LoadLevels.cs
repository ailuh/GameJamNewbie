using SaveData;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace UI
{
    public class LoadLevels : MonoBehaviour
    {
        [FormerlySerializedAs("saveManager")] [SerializeField] private SaveController saveController;
        public void StartLastOpenedLevel()
        {
            var lastLevel = saveController.LoadLastLevel();
            SceneManager.LoadScene( $"Level{lastLevel}");
        }   

        public void ReturnToMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void SelectLevel()
        {
            var level = EventSystem.current.currentSelectedGameObject.name;
            SceneManager.LoadScene(level);
        }
    }
}
