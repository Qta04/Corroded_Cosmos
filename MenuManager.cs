using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject startMenuPanel;
    public GameObject pauseMenuPanel;
    public GameObject gameOverPanel;

    private bool isPaused = false;

    void Start()
    {
        ShowStartMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ShowStartMenu()
    {
        startMenuPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        Time.timeScale = 0; // Asegúrate de que el juego esté en marcha
    }

    public void StartGame()
    {
        startMenuPanel.SetActive(false);
        // Aquí puedes cargar la escena del juego, por ejemplo:
        // SceneManager.LoadScene("GameScene");
        Time.timeScale = 1; // Asegúrate de que el juego esté en marcha
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0; // Pausa el juego
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1; // Reanuda el juego
    }

    public void RestartGame()
    {
        // Aquí puedes reiniciar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 0; // Asegúrate de que el juego esté en marcha
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0; // Pausa el juego
    }

    public void GameOverRestart()
    {
        RestartGame();
    }

    public void GameOverExit()
    {
        RestartGame();
    }
}
