using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;  

public class StoreManager : MonoBehaviour
{
    [SerializeField] private WalletManager walletManager;
    [SerializeField] private int[] skinPrices = { 0, 500, 1000 };
    [SerializeField] private GameObject[] skinButtons;
    [SerializeField] private TextMeshProUGUI[] buttonTexts;
    
    private int _currentSkinId;
    
    private void Start()
    {
        LoadSkinSelection();
        UpdateStoreUI();
    }

    public void BuyOrSelectSkin(int skinId)
    {
        bool isPurchased = PlayerPrefs.GetInt("SkinPurchased_" + skinId, 0) == 1;
        
        if (!isPurchased && walletManager.SpendCoins(skinPrices[skinId]))
        {
            PlayerPrefs.SetInt("SkinPurchased_" + skinId, 1);
        }

        if (isPurchased || skinId == 0)
        {
            SelectSkin(skinId);
        }
        
        UpdateStoreUI();
    }

    private void SelectSkin(int skinId)
    {
        _currentSkinId = skinId;
        PlayerPrefs.SetInt("SelectedSkin", skinId);
        
        SkinManager.Instance.SetSkin(skinId);
    }

    private void LoadSkinSelection()
    {
        _currentSkinId = PlayerPrefs.GetInt("SelectedSkin", 0);
    }
    
    private void UpdateStoreUI()
    {
        for (int i = 0; i < skinButtons.Length; i++)
        {
            bool isPurchased = i == 0 || PlayerPrefs.GetInt("SkinPurchased_" + i, 0) == 1;
            bool isSelected = i == _currentSkinId;
            
            skinButtons[i].GetComponent<Button>().interactable = isPurchased || walletManager.TotalCoins >= skinPrices[i];
            
            if (isSelected)
            {
                buttonTexts[i].text = "Selected";
            }
            else if (isPurchased)
            {
                buttonTexts[i].text = "Select";
            }
            else
            {
                buttonTexts[i].text = "Buy";
            }
        }
    }
}
