using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool GameIsOver = false;
    public static bool GameIsWon = false;
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public GameObject winScreenUI;

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
                Pause();
            }
        }

        if (GameIsOver == true)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }

        if (GameIsWon == true)
        {
            winScreenUI.SetActive(true);
            Time.timeScale = 0f;
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

    public void RestartGame()
    {
        gameOverUI.SetActive(false);
        winScreenUI.SetActive(false);
        GameIsOver = false;
        GameIsWon = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
        Debug.Log("restart successful");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit successful");
    }
}
