using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private Toggle musicToggle;

    private void Start()
    {
        Load();
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void Load()
    {
        bool soundOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
        soundToggle.isOn = soundOn;
        
        bool musicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;
        musicToggle.isOn = musicOn;
    }

    private void SubscribeToEvents()
    {
        soundToggle.onValueChanged.AddListener(OnSoundToggleChanged);
        musicToggle.onValueChanged.AddListener(OnMusicToggleChanged);
    }

    private void UnsubscribeFromEvents()
    {
        soundToggle.onValueChanged.RemoveListener(OnSoundToggleChanged);
        musicToggle.onValueChanged.RemoveListener(OnMusicToggleChanged);
    }

    private void OnSoundToggleChanged(bool isOn)
    {
        AudioController.Instance.SetSound(isOn);
    }

    private void OnMusicToggleChanged(bool isOn)
    {
        AudioController.Instance.SetMusic(isOn);
    }
}