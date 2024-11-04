using UnityEngine;
using UnityEngine.UI;

public class LoadLevelButton : MonoBehaviour
{
	[SerializeField] private int index;
	private Button _button;

	private void Awake()
	{
		_button = GetComponent<Button>();
		_button.onClick.AddListener(LoadScene);
	}

	private void LoadScene()
	{
		LevelManager.Instance.LoadLevel(index);
	}
}