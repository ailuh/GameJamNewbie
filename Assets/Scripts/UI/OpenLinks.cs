using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class OpenLinks : MonoBehaviour
    {
        [SerializeField] 
        private Button developerButton;
        [SerializeField] 
        private Button artistButton;
        [SerializeField] 
        private Button gameJamButton;
        [SerializeField] 
        private Button musicButton;

        private readonly string _developerUrl = "https://www.linkedin.com/in/antonilukhin/";
        private readonly string _artistUrl = "https://www.linkedin.com/in/mariya-ilyukhina-79387916b/";
        private readonly string _gameUrl = "https://itch.io/jam/ultra2";
        private readonly string _musicUrl = "https://pixabay.com/users/nojisuma-23737290/";

        private void Start()
        {
            developerButton.onClick.AddListener(OpenDeveloper);
            artistButton.onClick.AddListener(OpenArtist);
            gameJamButton.onClick.AddListener(OpenGame);
            musicButton.onClick.AddListener(OpenMusic);
        }

        private void OpenDeveloper() => Application.OpenURL(_developerUrl);
        private void OpenArtist() => Application.OpenURL(_artistUrl);
        private void OpenGame() => Application.OpenURL(_gameUrl);
        private void OpenMusic() => Application.OpenURL(_musicUrl);
    }
}
