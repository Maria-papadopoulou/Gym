using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public Canvas interactionCanvas;

    void Start()
    {
        interactionCanvas.enabled = false; // Hide the interaction UI initially
        pauseMenuUI.SetActive(false); // Hide the pause menu initially
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        interactionCanvas.enabled = true; // Show the interaction UI
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        interactionCanvas.enabled = false; // Hide the interaction UI
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Resume time before switching scenes
        SceneManager.LoadScene("Main Menu");
    }

    public void Settings_button()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Exit_button()
    {
        SceneManager.LoadScene("Exit");

    }
}
