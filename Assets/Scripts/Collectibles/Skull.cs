using UnityEngine;

public class Skull : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LifeController lifeController = FindObjectOfType<LifeController>();
            
            if (lifeController != null)
            {
                lifeController.LoseLife();
            }
            
            AudioController.Instance.PlaySound("Skull");
            
            Destroy(gameObject);
        }
    }
}
