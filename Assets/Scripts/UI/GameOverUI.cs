using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject tryAgainPanel;
    [SerializeField] private GameObject levelCompletePanel;
    
    [SerializeField] private TextMeshProUGUI tryAgainScoreText;
    [SerializeField] private TextMeshProUGUI levelCompleteScoreText;
    
    [SerializeField] private Image[] tryAgainStars;
    [SerializeField] private Image[] levelCompleteStars;
    
    [SerializeField] private Sprite grayStarSprite;
    [SerializeField] private Sprite yellowStarSprite;

    private const int StarsPerLevel = 3;

    public void ShowGameOver(int score, int starsEarned)
    {
        gameObject.SetActive(true);
        
        if (starsEarned == 3)
        {
            levelCompletePanel.SetActive(true);
            tryAgainPanel.SetActive(false);
            levelCompleteScoreText.text = "Score: " + score;
            UpdateStarImages(levelCompleteStars, starsEarned);
        }
        else
        {
            tryAgainPanel.SetActive(true);
            levelCompletePanel.SetActive(false);
            tryAgainScoreText.text = "Score: " + score;
            UpdateStarImages(tryAgainStars, starsEarned);
        }
    }

    public void OnTryAgainPressed()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnExitToMenuPressed()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(Scenes.MenuScene.ToString());
    }

    public void OnNextLevelPressed()
    {
        Time.timeScale = 1.0f;
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;

        if (nextLevelIndex > LevelManager.Instance.GetTotalLevels())
        {
            SceneManager.LoadScene(currentLevelIndex);
        }
        else
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
    }

    private void UpdateStarImages(Image[] starImages, int starsEarned)
    {
        for (int i = 0; i < StarsPerLevel; i++)
        {
            starImages[i].sprite = i < starsEarned ? yellowStarSprite : grayStarSprite;
        }
    }
}
