using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private Toggle musicToggle;

    private void Start()
    {
        bool soundOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
        soundToggle.isOn = soundOn;
        
        soundToggle.onValueChanged.AddListener(OnSoundToggleChanged);
        
        bool musicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;
        musicToggle.isOn = musicOn;
        
        musicToggle.onValueChanged.AddListener(OnMusicToggleChanged);
    }

    private void OnSoundToggleChanged(bool isOn)
    {
        SoundManager.Instance.SetSound(isOn);
    }
    
    private void OnMusicToggleChanged(bool isOn)
    {
        SoundManager.Instance.SetMusic(isOn);
    }

    private void OnDestroy()
    {
        soundToggle.onValueChanged.RemoveListener(OnSoundToggleChanged);
        musicToggle.onValueChanged.RemoveListener(OnMusicToggleChanged);
    }
}
