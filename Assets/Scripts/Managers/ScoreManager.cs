using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public UnityEvent<int> OnScoreChanged;

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

    public void ResetScore()
    {
        _score = 0;
        OnScoreChanged?.Invoke(_score);
    }

    public void AddScore(int points)
    {
        _score += points;
        OnScoreChanged?.Invoke(_score);
    }
    
    public int GetScore()
    {
        return _score;
    }

    public void CompleteLevel()
    {
        LevelManager.Instance.CompleteLevel(_score);
        int starsEarned = LevelManager.Instance.CalculateStars(_score);
        GameOverUI.Instance.ShowGameOver(_score, starsEarned);
    }
}
