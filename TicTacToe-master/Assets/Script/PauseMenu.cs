using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject drawMenuUI;
    public GameObject winnerOMenu;
    public GameObject winnerXMenu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                if (!drawMenuUI.activeSelf && !winnerOMenu.activeSelf && !winnerXMenu.activeSelf)
                    Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ShowDraw()
    {
        drawMenuUI.SetActive(true);
    }

    public void ShowWinnerXMenu()
    {
        winnerXMenu.SetActive(true);
    }

    public void ShowWinnerOMenu()
    {
        winnerOMenu.SetActive(true);
    }

    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene("MenuScene");
    }

    public void RestartGame()
    {
        Resume();
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
