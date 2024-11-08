using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionUI : MonoBehaviour
{
    public static LevelSelectionUI Instance;
    
    [SerializeField] private Button[] levelButtons;
    [SerializeField] private Image[] starImages;
    [SerializeField] private Sprite grayStarSprite;
    [SerializeField] private Sprite yellowStarSprite;

    private const int StarsPerLevel = 3;

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
        UpdateLevelSelectionUI();
    }

    public void UpdateLevelSelectionUI()
    {
        for (int levelIndex = 0; levelIndex < levelButtons.Length; levelIndex++)
        {
            int starsAchieved = LevelManager.Instance.GetStarsForLevel(levelIndex);

            levelButtons[levelIndex].interactable = LevelManager.Instance.IsLevelUnlocked(levelIndex);
            
            int startIndex = levelIndex * StarsPerLevel;
            
            for (int starIndex = 0; starIndex < StarsPerLevel; starIndex++)
            {
                starImages[startIndex + starIndex].sprite = starIndex < starsAchieved ? yellowStarSprite : grayStarSprite;
            }
        }
    }
}
