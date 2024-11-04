using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound;
    
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
        
        audioSource = GetComponent<AudioSource>();
        LoadSound();
    }

    public void SetSound(bool isOn)
    {
        audioSource.mute = !isOn;
        PlayerPrefs.SetInt("SoundOn", isOn ? 1 : 0);
    }

    public void PlayClickSound()
    {
        if (clickSound != null && !audioSource.mute)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

    private void LoadSound()
    {
        bool soundOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
        SetSound(soundOn);
    }
}
