using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public AudioSource audioSource;
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
    private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();


    void Start()
    {
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
        SceneManager.sceneLoaded += StartMusic;
        audioSource.clip = ClipMain;
        DontDestroyOnLoad(this);
        _buttonSprite = musicButton.GetComponent<Image>();
        audioSource.Play();
    }

    private void TurnOnOffMusic()
    {
        _isMusic = !_isMusic;
        if (_isMusic)
        {
            _buttonSprite.sprite = soundOn;
            audioSource.Play();
        }
        else
        {
            _buttonSprite.sprite = soundOff;
            audioSource.Stop();
        }
    }
    
    private void StartMusic(Scene scene, LoadSceneMode loadSceneMode)
    {
        var newTrack = _audioClips[scene.name];
        if (audioSource.clip != newTrack)
        {
            audioSource.Stop();
            audioSource.clip = newTrack;
            if (_isMusic)
                audioSource.Play();
            else
                audioSource.Stop();
        }
    }

}
    