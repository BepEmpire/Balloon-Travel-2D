using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int scoreValue = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreController.Instance.AddScore(scoreValue);
            
            AudioController.Instance.PlaySound("Score");
            
            Destroy(gameObject);
        }
    }
}