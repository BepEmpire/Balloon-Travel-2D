using System;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static SkinManager Instance { get; private set; }

    [SerializeField] private int currentSkinId = 0;
    
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

        LoadSkin();
    }

    public int GetCurrentSkinId()
    {
        return currentSkinId;
    }

    public void SetSkin(int skinId)
    { 
        currentSkinId = skinId; 
        PlayerPrefs.SetInt("CurrentSkinId", skinId);
        PlayerPrefs.Save();
    }

    private void LoadSkin()
    {
        currentSkinId = PlayerPrefs.GetInt("CurrentSkinId", 0);
    }
}
