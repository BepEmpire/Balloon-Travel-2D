using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    private bool _isPaused = false;

    public void TogglePause()
    {
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            Time.timeScale = 0.0f;
            gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            gameObject.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        TogglePause();
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(Scenes.MenuScene.ToString());
    }
}
