using UnityEngine;

public class LevelSelectionUI : MonoBehaviour
{
    [SerializeField] private LevelButton[] levelButtons;
    
    private void Start()
    {
        UpdateLevelSelectionUI();
    }

    private void UpdateLevelSelectionUI()
    {
        for (int levelIndex = 0; levelIndex < levelButtons.Length; levelIndex++)
        {
            bool isInteractable = LevelManager.Instance.IsLevelUnlocked(levelIndex);
            int starsAchieved = LevelManager.Instance.GetStarsForLevel(levelIndex);

            levelButtons[levelIndex].Init(isInteractable, starsAchieved);
        }
    }
}