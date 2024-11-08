using UnityEngine;

public class Skull : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LifeManager lifeManager = FindObjectOfType<LifeManager>();
            
            if (lifeManager != null)
            {
                lifeManager.LoseLife();
            }
            
            SoundManager.Instance.PlaySound("Skull");
            
            Destroy(gameObject);
        }
    }
}
