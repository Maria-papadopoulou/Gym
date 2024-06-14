using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGame : MonoBehaviour
{
    public ShopManager shopManager;

    public void ConfirmButton() {
        // Save the current coins to PlayerPrefs
        // PlayerPrefs.SetFloat("PlayerCoins", shopManager.coins);
        // PlayerPrefs.Save();

        // Load the "Game" scene
        SceneManager.LoadScene("Game");
    }
}
