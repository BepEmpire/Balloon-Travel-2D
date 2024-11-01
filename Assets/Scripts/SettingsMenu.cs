using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Toggle soundToggle;

    private void Start()
    {
        bool soundOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
        soundToggle.isOn = soundOn;
        
        soundToggle.onValueChanged.AddListener(OnSoundToggleChanged);
    }

    private void OnSoundToggleChanged(bool isOn)
    {
        SoundManager.Instance.SetSound(isOn);
    }

    private void OnDestroy()
    {
        soundToggle.onValueChanged.RemoveListener(OnSoundToggleChanged);
    }
}
