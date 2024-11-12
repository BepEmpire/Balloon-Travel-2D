using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
	private TextMeshProUGUI _text;

	private void Awake()
	{
		_text = GetComponent<TextMeshProUGUI>();
	}

	public void SetText(int score)
	{
		_text.text = score.ToString();
	}
}