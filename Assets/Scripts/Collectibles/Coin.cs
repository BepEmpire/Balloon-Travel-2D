using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            WalletManager wallet = FindObjectOfType<WalletManager>();
            
            if (wallet != null)
            {
                wallet.AddCoins(coinValue);
            }
            
            AudioController.Instance.PlaySound("Coin");
            
            Destroy(gameObject);
        }
    }
}
