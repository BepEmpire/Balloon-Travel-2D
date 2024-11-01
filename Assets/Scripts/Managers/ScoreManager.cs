using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    
    public TextMeshProUGUI ScoreText => scoreText;
    
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField, Min(0)] private int score = 0;
    
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
        StartCoroutine(IncreaseScoreOverTime());
    }

    private IEnumerator IncreaseScoreOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            AddScore(1);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }
    
    private void UpdateScoreUI()
    {
        scoreText.text = score.ToString();
    }
}
