using UnityEngine;
using TMPro;

public class DisplayCoins : MonoBehaviour
{
	private TextMeshProUGUI _text;

	private void Awake()
	{
		_text = GetComponent<TextMeshProUGUI>();
	}

	private void Start()
	{
		SetText(WalletManager.Instance.TotalCoins);
		WalletManager.Instance.OnWalletChanged.AddListener(SetText);
	}

	private void OnDestroy()
	{
		WalletManager.Instance.OnWalletChanged.RemoveListener(SetText);
	}

	private void SetText(int coins)
	{
		_text.text = coins.ToString();
	}
}