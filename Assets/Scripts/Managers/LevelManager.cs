using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    
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
    }

    private void Start()
    {
        SoundManager.Instance.PlayMusic("Menu Scene");
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);

        switch (index)
        {
            case 0:
                SoundManager.Instance.PlayMusic("Menu Scene");
                break;
            case 1:
                SoundManager.Instance.PlayMusic("Level 1");
                break;
        }
    }
}
