using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private LevelData[] levelsData;
    
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
    }

    public int GetTotalLevels()
    {
        return levelsData.Length;
    }

    public void CompleteLevel(int score)
    {
        int starCount = CalculateStars(score);
        int currentLevelIndex = GetCurrentLevelIndex();
        
        levelsData[currentLevelIndex].starsEarned = Mathf.Max(levelsData[currentLevelIndex].starsEarned, starCount);
        
        if (starCount == 3 && currentLevelIndex + 1 < levelsData.Length)
        {
            levelsData[currentLevelIndex + 1].isUnlocked = true;
        }

        SaveProgress();
    }

    public int CalculateStars(int score)
    {
        int currentLevelIndex = GetCurrentLevelIndex();
        
        return levelsData[currentLevelIndex].CalculateStars(score);
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

    private int GetCurrentLevelIndex()
    {
        return SceneManager.GetActiveScene().buildIndex - 1;
    }
}