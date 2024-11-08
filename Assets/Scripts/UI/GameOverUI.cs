using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance;
    
    [SerializeField] private GameObject tryAgainPanel;
    [SerializeField] private GameObject levelCompletePanel;
    
    [SerializeField] private TextMeshProUGUI tryAgainScoreText;
    [SerializeField] private TextMeshProUGUI levelCompleteScoreText;
    
    [SerializeField] private Image[] tryAgainStars;
    [SerializeField] private Image[] levelCompleteStars;
    
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

    public void ShowGameOver(int score, int starsEarned)
    {
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

    private void UpdateStarImages(Image[] starImages, int starsEarned)
    {
        for (int i = 0; i < StarsPerLevel; i++)
        {
            starImages[i].sprite = i < starsEarned ? yellowStarSprite : grayStarSprite;
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
        LevelManager.Instance.LoadLevel(0);
    }

    public void OnNextLevelPressed()
    {
        Time.timeScale = 1.0f;
        LevelManager.Instance.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
