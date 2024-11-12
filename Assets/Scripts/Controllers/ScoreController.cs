using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;

    public UnityEvent<int> OnScoreChanged;

    [SerializeField] private GameOverUI gameOverUI;
    
    private int _score = 0;
    
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
        ResetScore();
    }

    private void ResetScore()
    {
        _score = 0;
        OnScoreChanged?.Invoke(_score);
    }

    public void AddScore(int points)
    {
        _score += points;
        OnScoreChanged?.Invoke(_score);
    }

    public void CompleteLevel()
    {
        LevelManager.Instance.CompleteLevel(_score);
        int starsEarned = LevelManager.Instance.CalculateStars(_score);
        gameOverUI.ShowGameOver(_score, starsEarned);
    }
}