using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnlineHelp : MonoBehaviour
{
    public void GoToPreviousScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
