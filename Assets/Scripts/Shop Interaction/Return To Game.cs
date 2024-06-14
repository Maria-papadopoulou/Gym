using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGame : MonoBehaviour
{
    // This function will be called when the Confirm button is pressed
    public void ConfirmButton() {
        SceneManager.LoadScene("Game");

    }
}
