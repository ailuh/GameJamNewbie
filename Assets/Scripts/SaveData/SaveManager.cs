using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private const string Levels = "Openedlevels";
    private int openedLevels;
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

   
}
