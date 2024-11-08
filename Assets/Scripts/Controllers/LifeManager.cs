using System;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private int totalLives = 3;
    [SerializeField] private Image[] liveImages;
    [SerializeField] private Sprite liveEnabled;
    [SerializeField] private Sprite liveDisabled;
    [SerializeField] private GameObject gameOverContainer;
    
    private int _currentLives;

    private void Start()
    {
        _currentLives = totalLives;
        UpdateLivesUI();
    }

    public void LoseLife()
    {
        _currentLives--;
        UpdateLivesUI();

        if (_currentLives <= 0)
        {
            GameOver();
        }
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < liveImages.Length; i++)
        {
            if (i < _currentLives)
            {
                liveImages[i].sprite = liveEnabled;
                liveImages[i].enabled = true;
            }
            else
            {
                liveImages[i].sprite = liveDisabled;
                liveImages[i].enabled = true;
            }
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOverContainer.SetActive(true);

        ScoreManager.Instance.CompleteLevel();
        //int score = ScoreManager.Instance.GetScore();
        //int starsEarned = LevelManager.Instance.CalculateStars(score);

        //GameOverUI.Instance.ShowGameOver(score, starsEarned);
    }
}
