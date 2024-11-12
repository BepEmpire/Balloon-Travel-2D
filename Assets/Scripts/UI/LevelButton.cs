using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
	[SerializeField] private Scenes scene;
	[SerializeField] private Image[] starImages;
	[SerializeField] private Sprite starActiveSprite;
	[SerializeField] private Sprite starInactiveSprite;

	private Button _button;

	private void Awake()
	{
		_button = GetComponent<Button>();
		_button.onClick.AddListener(LoadScene);
	}

	public void Init(bool isInteractable, int starsAchieved)
	{
		_button.interactable = isInteractable;

		for (int i = 0; i < starImages.Length; i++)
		{
			starImages[i].sprite = i < starsAchieved ? starActiveSprite : starInactiveSprite;
		}
	}
	
	private void LoadScene()
	{
		SceneManager.LoadScene(scene.ToString());
	}
}