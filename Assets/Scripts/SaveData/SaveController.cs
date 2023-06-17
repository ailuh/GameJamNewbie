using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SaveData
{
    public class SaveController : MonoBehaviour
    {
        private const string Levels = "Openedlevels";
        private int _openedLevels;
        private readonly string _pattern = @"[a-zA-Z]+(\d+)";
        private void Start()
        {
            if (PlayerPrefs.HasKey(Levels))
            {
                _openedLevels = PlayerPrefs.GetInt(Levels);
            }
            else
            {
                _openedLevels = 1;
                SaveDate(_openedLevels);
            }
        }

        public int LoadLastLevel()
        {
            return PlayerPrefs.GetInt(Levels);

        }

        private void SaveDate(int levelOpened)
        {
            if (levelOpened <= 10)
            {
                _openedLevels = PlayerPrefs.GetInt(Levels);
                if (levelOpened <= _openedLevels) return;
                PlayerPrefs.SetInt(Levels, levelOpened);
            }
        
        }

        public void OpenNextLevel()
        {
            var lvlNum = SceneManager.GetActiveScene().name;
            var result = Regex.Match(lvlNum, _pattern);
            SaveDate( int.Parse(result.Groups[1].Value)+ 1);
        }

        public void ResetOpenedLevels()
        {
            PlayerPrefs.SetInt(Levels, 1);
        }
    
        public int ReturnOpenedLevelsCount =>  PlayerPrefs.GetInt(Levels);
   
    }
}
