using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSettingsMenu : MonoBehaviour
{
    public static bool SettingsIsPaused;

    public GameObject SettingsMenuUI;

    public void Resume()
    {
        SettingsMenuUI.SetActive(false);
        SettingsIsPaused = false;
    }

    public void Pause()
    {
        SettingsMenuUI.SetActive(true);
        SettingsIsPaused = true;
    }
}
