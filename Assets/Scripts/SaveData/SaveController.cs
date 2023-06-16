using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    private const string Levels = "Openedlevels";
    private int openedLevels;
    private string pattern = @"[a-zA-Z]+(\d+)";
    private void Start()
    {
        if (PlayerPrefs.HasKey(Levels))
        {
            openedLevels = PlayerPrefs.GetInt("masterVolume");
        }
        else
        {
            openedLevels = 1;
            SaveDate(openedLevels);
        }
    }

    public int LoadLastLevel()
    {
        return PlayerPrefs.GetInt(Levels);

    }
    
    public void SaveDate(int levelOpened)
    {
        PlayerPrefs.SetInt(Levels, levelOpened);
    }

    public void OpenNextLevel()
    {
        var lvlNum = SceneManager.GetActiveScene().name;
        var result = Regex.Match(lvlNum, pattern);
        SaveDate( int.Parse(result.Groups[1].Value)+ 1);
    }

    public void ResetOpenedLevels()
    {
        PlayerPrefs.SetInt(Levels, 1);
    }
    
    public int ReturnOpenedLevelsCount =>  PlayerPrefs.GetInt(Levels);
   
}
