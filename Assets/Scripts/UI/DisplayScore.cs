using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
	private TextMeshProUGUI _text;

	private void Awake()
	{
		_text = GetComponent<TextMeshProUGUI>();
	}

	private void Start()
	{
		SetText(0);
		ScoreManager.Instance.OnScoreChanged.AddListener(SetText);
	}

	private void OnDestroy()
	{
		ScoreManager.Instance.OnScoreChanged.RemoveListener(SetText);
	}

	private void SetText(int score)
	{
		_text.text = score.ToString();
	}
}