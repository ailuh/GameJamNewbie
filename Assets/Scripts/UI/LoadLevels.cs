using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour
{
    [SerializeField] private SaveManager saveManager;
    public void StartLastOpenedLevel()
    {
        var lastLevel = saveManager.LoadLastLevel();
        SceneManager.LoadScene( $"Level{lastLevel}");
    }
}
