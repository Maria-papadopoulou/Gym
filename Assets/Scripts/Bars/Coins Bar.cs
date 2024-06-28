using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsBar : MonoBehaviour
{
    public TMP_Text coinText; // The TextMeshPro component to display the current energy
    private float coins = 0; // The current energy of the player
    
    // Start is called before the first frame update
    void Start()
    {
        LoadCoins();
    }
    // Update is called once per frame
    void Update()
    {
        LoadCoins();
    }

    void LoadCoins()
    {
        // Load the energy value from PlayerPrefs
        coins = PlayerPrefs.GetFloat("PlayerCoins"); // Default to 0 if not found
        coinText.text = "Coins: " + coins.ToString();
    }
}
