using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Show and unlock the cursor in the shop scene
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
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
    }
  public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("Main Menu");
    }
    public void Settings_button()
   {
        Time.timeScale=0f;
        SceneManager.LoadScene("Settings");
   }

   public void Exit_button()
   {
        SceneManager.LoadScene("Exit");
   }
}
