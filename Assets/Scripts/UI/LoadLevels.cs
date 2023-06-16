using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

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
}
