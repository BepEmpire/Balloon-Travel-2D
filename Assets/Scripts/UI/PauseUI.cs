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
            SetTimeScaleToOne();
            gameObject.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        TogglePause();
    }

    public void RestartGame()
    {
        SetTimeScaleToOne();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        SetTimeScaleToOne();
        SceneManager.LoadScene(Scenes.MenuScene.ToString());
    }

    private void SetTimeScaleToOne()
    {
        Time.timeScale = 1.0f;
    }
}