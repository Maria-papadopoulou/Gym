using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenExit : MonoBehaviour
{
    public static bool ExitIsPaused;

    public GameObject ExitMenuUI;

    public void Resume()
    {
        ExitMenuUI.SetActive(false);
        ExitIsPaused = false;
    }

    public void Pause()
    {
        ExitMenuUI.SetActive(true);
        ExitIsPaused = true;
    }
}
