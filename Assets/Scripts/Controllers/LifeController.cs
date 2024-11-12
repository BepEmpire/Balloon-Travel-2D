using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    [Header("Links")] 
    [SerializeField] private ObjectSpawner[] objectSpawners;
    
    [Header("Images And Sprites")]
    [SerializeField] private Image[] liveImages;
    [SerializeField] private Sprite liveEnabled;
    [SerializeField] private Sprite liveDisabled;
    
    [Header("Life Settings")]
    [SerializeField] private int totalLives = 3;
    
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
        ScoreController.Instance.CompleteLevel();

        foreach (var objectSpawner in objectSpawners)
        {
            objectSpawner.StopSpawn();
        }
    }
}
