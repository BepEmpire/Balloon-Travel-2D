using UnityEngine;

public class WalletManager : MonoBehaviour
{
    private const string WALLET_KEY = "TotalCoins";
    public int TotalCoins { get; private set; }

    private void Awake()
    {
        TotalCoins = PlayerPrefs.GetInt(WALLET_KEY, 0);
    }
    
    public void AddCoins(int coins)
    {
        TotalCoins += coins;
        PlayerPrefs.SetInt(WALLET_KEY, TotalCoins);
        PlayerPrefs.Save();
    }
}
