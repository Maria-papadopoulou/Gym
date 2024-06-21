using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenInput : MonoBehaviour
{
    public static bool ShopIsPaused;

    public GameObject shopMenuUI;

    public void Resume()
    {
        shopMenuUI.SetActive(false);
        Time.timeScale = 1f;
        ShopIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        shopMenuUI.SetActive(true);
        Time.timeScale = 0f;
        ShopIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
