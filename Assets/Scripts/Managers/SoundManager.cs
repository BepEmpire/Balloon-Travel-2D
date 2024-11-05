using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    
    [Header("Audio Sources")]
    [SerializeField] private AudioSource soundEffectsSource;
    [SerializeField] private AudioSource musicSource;
    
    [Header("Sound and Music Clips")]
    [SerializeField] private AudioClip[] sounds;
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        LoadAudioSettings();
    }

    public void SetSound(bool isOn)
    {
        soundEffectsSource.mute = !isOn;
        PlayerPrefs.SetInt("SoundOn", isOn ? 1 : 0);
    }

    public void PlaySound(string soundName)
    {
        AudioClip clip = FindAudioClipByName(soundName);
        
        if (clip != null && !soundEffectsSource.mute)
        {
            soundEffectsSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning($"AudioClip {soundName} not found");
        }
    }
    
    private AudioClip FindAudioClipByName(string soundName)
    {
        foreach (AudioClip audioClip in sounds)
        {
            if (audioClip.name == soundName)
            {
                return audioClip;
            }
        }
        
        return null;
    }
    
    public void SetMusic(bool isOn)
    {
        musicSource.mute = !isOn;
        PlayerPrefs.SetInt("MusicOn", isOn ? 1 : 0);
    }
    
    public void PlayMusic(string scene)
    {
        AudioClip musicClip = null;

        if (scene == "Menu Scene")
        {
            musicClip = menuMusic;
        }
        else if (scene == "Level 1")
        {
            musicClip = gameMusic;
        }

        if (musicClip != null && musicSource.clip != musicClip)
        {
            musicSource.clip = musicClip;
            musicSource.Play();
        }
    }
    
    private void LoadAudioSettings()
    {
        bool soundOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
        bool musicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;
        
        SetSound(soundOn);
        SetMusic(musicOn);
    }
}
