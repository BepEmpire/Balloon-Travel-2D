using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private LevelData[] levelsData;
    [SerializeField] private int[] scoreThresholds = { 500, 1000, 1500 };
    
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

        LoadProgress();

        if (LevelSelectionUI.Instance != null)
        {
            LevelSelectionUI.Instance.UpdateLevelSelectionUI();
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

    public LevelData GetLevelData(int levelIndex)
    {
        return levelsData[levelIndex];
    }

    public void CompleteLevel(int score)
    {
        int starCount = CalculateStars(score);
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex - 1;
        
        levelsData[currentLevelIndex].starsEarned = Mathf.Max(levelsData[currentLevelIndex].starsEarned, starCount);
        
        if (starCount == 3 && currentLevelIndex + 1 < levelsData.Length)
        {
            levelsData[currentLevelIndex + 1].isUnlocked = true;
        }

        SaveProgress();
    }

    public int CalculateStars(int score)
    {
        if (score >= scoreThresholds[2]) return 3;
        if (score >= scoreThresholds[1]) return 2;
        if (score >= scoreThresholds[0]) return 1;
        return 0;
    }

    private void SaveProgress()
    {
        for (int i = 0; i < levelsData.Length; i++)
        {
            PlayerPrefs.SetInt($"Level_{i}_Stars", levelsData[i].starsEarned);
            PlayerPrefs.SetInt($"Level_{i}_Unlocked", levelsData[i].isUnlocked ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    private void LoadProgress()
    {
        for (int i = 0; i < levelsData.Length; i++)
        {
            levelsData[i].starsEarned = PlayerPrefs.GetInt($"Level_{i}_Stars", 0);
            levelsData[i].isUnlocked = PlayerPrefs.GetInt($"Level_{i}_Unlocked", i == 0 ? 1 : 0) == 1;
        }
    }

    public int GetStarsForLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= levelsData.Length) return 0;
        return levelsData[levelIndex].starsEarned;
    }

    public bool IsLevelUnlocked(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= levelsData.Length) return false;
        return levelsData[levelIndex].isUnlocked;
    }
}
