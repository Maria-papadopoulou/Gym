using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Globalization;
using System.IO;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[2, 5];
    public float coins;
    public float fat;
    public float muscle;
    public float energy;

    public Text Coinstxt;

    void Update() {
        // Load the saved coins from PlayerPrefs
        if (PlayerPrefs.HasKey("PlayerCoins"))
        {
            coins = PlayerPrefs.GetFloat("PlayerCoins");
            fat=PlayerPrefs.GetFloat("Fat");
            muscle=PlayerPrefs.GetFloat("Muscle");
            energy=PlayerPrefs.GetFloat("Energy");
        }
        else
        {
            coins = 0;
        }
        Coinstxt.text = "Coins: " + coins.ToString();
    }

    void Start()
    {
        // Show and unlock the cursor in the shop scene
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        // Load the saved coins from PlayerPrefs
        if (PlayerPrefs.HasKey("PlayerCoins"))
        {
            coins = PlayerPrefs.GetFloat("PlayerCoins");
            fat=PlayerPrefs.GetFloat("Fat");
            muscle=PlayerPrefs.GetFloat("Muscle");
            energy=PlayerPrefs.GetFloat("Energy");
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
        shopItems[0, 4] = 5; 


        // Prices
        shopItems[1, 0] = 15;
        shopItems[1, 1] = 15;
        shopItems[1, 2] = 30;
        shopItems[1, 3] = 35;
        shopItems[1, 4] = 20;

    }

    public void Buy()
    {
        GameObject buttonInfo = EventSystem.current.currentSelectedGameObject;
        ButtonInfo buttonScript = buttonInfo.GetComponent<ButtonInfo>();
        int itemID = buttonScript.ItemID;

        if (coins >= shopItems[1, itemID - 1])  // Adjusted to match the array index
        {
            coins -= shopItems[1, itemID - 1];
            PlayerPrefs.SetFloat("PlayerCoins", coins);
            Coinstxt.text = "Coins: " + coins.ToString();
            
            fat += 5f;
            muscle -= 5f;
            energy += 5f;

            // Ensure fat is within range (10, 90)
            if (fat > 90)
            {
                float diff = fat - 90;
                fat -= diff;
                muscle += diff;
            }
            else if (fat < 10)
            {
                float diff = 10 - fat;
                fat += diff;
                muscle -= diff;
            }

            // Ensure muscle is within range (10, 90)
            if (muscle > 90)
            {
                float diff = muscle - 90;
                muscle -= diff;
                fat += diff;
            }
            else if (muscle < 10)
            {
                float diff = 10 - muscle;
                muscle += diff;
                fat -= diff;
            }

            // Ensure energy is within range (0, 100)
            if (energy > 100)
            {
                float diff = energy - 100;
                energy -= diff;
            }
            PlayerPrefs.SetFloat("Fat", fat);
            PlayerPrefs.SetFloat("Muscle", muscle);
            PlayerPrefs.SetFloat("Energy", energy);
            PlayerPrefs.Save();

            // Prepare data to save in a text file
            string dataPath = Application.persistentDataPath + "/UserData.txt";
            string dateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            string data = $"Date and Time: {dateTime}\n" +
                        $"Muscle: {PlayerPrefs.GetFloat("Muscle")}\n" +
                        $"Coins: {PlayerPrefs.GetFloat("PlayerCoins")}\n" +
                        $"Fat: {PlayerPrefs.GetFloat("Fat")}\n" +
                        $"Energy: {PlayerPrefs.GetFloat("Energy")}\n\n";

            // Append data to file
            File.AppendAllText(dataPath, data);
        }
    }

}
