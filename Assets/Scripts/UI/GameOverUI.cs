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

    private const int STARS_PER_LEVEL = 3;

    public void ShowGameOver(int score, int starsEarned)
    {
        gameObject.SetActive(true);
        
        if (starsEarned == 3)
        {
            LevelCompleted(score, starsEarned);
        }
        else
        {
            TryAgain(score, starsEarned);
        }
    }

    public void OnTryAgainPressed()
    {
        SetTimeScaleToOne();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnExitToMenuPressed()
    {
        SetTimeScaleToOne();
        SceneManager.LoadScene(Scenes.MenuScene.ToString());
    }

    public void OnNextLevelPressed()
    {
        SetTimeScaleToOne();
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

    private void LevelCompleted(int score, int starsEarned)
    {
        levelCompletePanel.SetActive(true);
        tryAgainPanel.SetActive(false);
        levelCompleteScoreText.text = "Score: " + score;
        UpdateStarImages(levelCompleteStars, starsEarned);
    }

    private void TryAgain(int score, int starsEarned)
    {
        tryAgainPanel.SetActive(true);
        levelCompletePanel.SetActive(false);
        tryAgainScoreText.text = "Score: " + score;
        UpdateStarImages(tryAgainStars, starsEarned);
    }

    private void UpdateStarImages(Image[] starImages, int starsEarned)
    {
        for (int i = 0; i < STARS_PER_LEVEL; i++)
        {
            starImages[i].sprite = i < starsEarned ? yellowStarSprite : grayStarSprite;
        }
    }

    private void SetTimeScaleToOne()
    {
        Time.timeScale = 1.0f;
    }
}