using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenOnlineHelp : MonoBehaviour
{
    public static bool OnlineHelpIsPaused;

    public GameObject OnlineHelpMenuUI;

    public void Resume()
    {
        OnlineHelpMenuUI.SetActive(false);
        OnlineHelpIsPaused = false;
    }

    public void Pause()
    {
        OnlineHelpMenuUI.SetActive(true);
        OnlineHelpIsPaused = true;
    }
}
