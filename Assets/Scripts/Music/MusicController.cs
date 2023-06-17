using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
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
        audioSource.Play();
        DontDestroyOnLoad(this);
    }

    private void StartMusic(Scene scene, LoadSceneMode loadSceneMode)
    {
        var newTrack = _audioClips[scene.name];
        if (audioSource.clip != newTrack)
        {
            audioSource.Stop();
            audioSource.clip = newTrack;
            audioSource.Play();
        }
    }

}
    