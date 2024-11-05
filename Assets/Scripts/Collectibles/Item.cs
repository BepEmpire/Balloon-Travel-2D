using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int scoreValue = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(scoreValue);
            
            SoundManager.Instance.PlaySound("Score");
            
            Destroy(gameObject);
        }
    }
}
