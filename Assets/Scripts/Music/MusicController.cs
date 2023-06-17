using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Music
{
    public class MusicController : MonoBehaviour
    {
        [SerializeField]
        private Sprite soundOn;
        [SerializeField]
        private Sprite soundOff;
        [SerializeField]
        private Button musicButton;
        private bool _isMusic;
        private Image _buttonSprite;
        private AudioSource _audioSource;
        public AudioClip ClipLevel1;
        public AudioClip ClipLevel2;
        public AudioClip ClipLevel3;
        public AudioClip ClipLevel4;
        public AudioClip ClipLevel5;
        public AudioClip ClipLevel6;
        public AudioClip ClipLevel7;
        public AudioClip ClipLevel8;
        public AudioClip ClipLevel9;
        public AudioClip ClipLevel10;
        public AudioClip ClipMain;
        private readonly Dictionary<string, AudioClip> _audioClips = new();

        void Awake()
        {
            /*var musicInstances = GameObject.FindGameObjectsWithTag(gameObject.tag);
            if (musicInstances.Length > 1)
            {
                foreach (var instance in musicInstances)
                {
                    if (gameObject != instance.gameObject)
                    {
                        DestroyImmediate(instance.gameObject);
                        return;
                    }
                }
            }*/
            _audioSource = GetComponent<AudioSource>();
            _isMusic = true;
            musicButton.onClick.AddListener(TurnOnOffMusic);
            _audioClips.Add("Level1", ClipLevel1);
            _audioClips.Add("Level2", ClipLevel2);
            _audioClips.Add("Level3", ClipLevel3);
            _audioClips.Add("Level4", ClipLevel4);
            _audioClips.Add("Level5", ClipLevel5);
            _audioClips.Add("Level6", ClipLevel6);
            _audioClips.Add("Level7", ClipLevel7);
            _audioClips.Add("Level8", ClipLevel8);
            _audioClips.Add("Level9", ClipLevel9);
            _audioClips.Add("Level10", ClipLevel10);
            _audioClips.Add("MainMenu", ClipMain);
            _audioSource.clip = ClipMain;
            DontDestroyOnLoad(this);
            _buttonSprite = musicButton.GetComponent<Image>();
            _audioSource.Play();
        }

        private void Start()
        {
            SceneManager.sceneLoaded += StartMusic;
        }

        private void TurnOnOffMusic()
        {
            _isMusic = !_isMusic;
            if (_isMusic)
            {
                _buttonSprite.sprite = soundOn;
                _audioSource.Play();
            }
            else
            {
                _buttonSprite.sprite = soundOff;
                _audioSource.Stop();
            }
        }
    
        private void StartMusic(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (scene.name == "MainMenu")
            {
                _audioSource.Stop();
                Destroy(this);
                return;
            }
            var newTrack = _audioClips[scene.name];
            if (_audioSource.clip != newTrack)
            {
                _audioSource.clip = newTrack;
                if (_isMusic)
                {
                    _audioSource.volume = 0.5f;
                    _audioSource.Play();
                }
                else
                    _audioSource.Stop();
            }
        }

    }
}
    