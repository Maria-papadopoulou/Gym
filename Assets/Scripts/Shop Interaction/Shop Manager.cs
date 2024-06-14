using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[3, 4];
    public float coins;
    public Text Coinstxt;

    void Start()
    {
        // Show and unlock the cursor in the shop scene
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        // Load the saved coins from PlayerPrefs
        if (PlayerPrefs.HasKey("PlayerCoins"))
        {
            coins = PlayerPrefs.GetFloat("PlayerCoins");
        }
        else
        {
            coins = 0;
        }

        Coinstxt.text = "Coins: " + coins.ToString();

        // IDs
        shopItems[0, 0] = 1; 
        shopItems[0, 1] = 2; 
        shopItems[0, 2] = 3; 
        shopItems[0, 3] = 4; 

        // Prices
        shopItems[1, 0] = 100;
        shopItems[1, 1] = 200;
        shopItems[1, 2] = 300;
        shopItems[1, 3] = 400;

        // Quantities
        shopItems[2, 0] = 0;
        shopItems[2, 1] = 0;
        shopItems[2, 2] = 0;
        shopItems[2, 3] = 0;
    }

    public void Buy()
    {
        GameObject buttonInfo = EventSystem.current.currentSelectedGameObject;
        ButtonInfo buttonScript = buttonInfo.GetComponent<ButtonInfo>();
        int itemID = buttonScript.ItemID;

        if (coins >= shopItems[1, itemID - 1])  // Adjusted to match the array index
        {
            coins -= shopItems[1, itemID - 1];
            shopItems[2, itemID - 1]++;
            Coinstxt.text = "Coins: " + coins.ToString();
            buttonScript.QuantityTxt.text = shopItems[2, itemID - 1].ToString();
        }
    }
}
