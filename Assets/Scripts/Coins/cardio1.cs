using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatsUpdater : MonoBehaviour
{
    private Timer timer;
    private ShopManager shopManager;
    private float updateInterval = 3f; // Διάστημα ενημέρωσης σε δευτερόλεπτα

    void Start()
    {
        // Βρες το Timer και το ShopManager script στο ίδιο GameObject ή στην σκηνή
        timer = FindObjectOfType<Timer>();
        shopManager = FindObjectOfType<ShopManager>();

        // Ξεκίνα το coroutine που θα ενημερώνει τα στατιστικά του παίκτη
        StartCoroutine(UpdatePlayerStatsCoroutine());
    }

    IEnumerator UpdatePlayerStatsCoroutine()
    {
        while (true)
        {
            // Περίμενε για το καθορισμένο διάστημα
            yield return new WaitForSeconds(updateInterval);

            // Αν το χρονόμετρο τρέχει, ενημέρωσε τα στατιστικά του παίκτη
            if (timer != null && shopManager != null && timer.isRunning)
            {
                UpdatePlayerStats();
            }
        }
    }

    void UpdatePlayerStats()
    {
        // Αύξηση των coins κατά 2
        shopManager.coins += 2;

        // Μείωση του fat κατά 5
        shopManager.fat -= 5;
        if (shopManager.fat < 10f)
        {
            shopManager.fat = 10;
        }

        // Αύξηση του muscle κατά 5
        shopManager.muscle += 5;
        if (shopManager.muscle > 90f)
        {
            shopManager.muscle = 90;
        }

        // Διατήρηση της συνθήκης muscle + fat = 100
        shopManager.fat = 100 - shopManager.muscle;

        // Βεβαιώσου ότι το fat και το muscle παραμένουν στα όρια (10, 90)
         if (shopManager.fat > 90)
            {
                float diff = shopManager.fat - 90;
                shopManager.fat -= diff;
                shopManager.muscle += diff;
            }
            else if (shopManager.fat < 10)
            {
                float diff = 10 - shopManager.fat;
                shopManager.fat += diff;
                shopManager.muscle -= diff;
            }

            // Ensure muscle is within range (10, 90)
            if (shopManager.muscle > 90)
            {
                float diff = shopManager.muscle - 90;
                shopManager.muscle -= diff;
                 shopManager.fat += diff;
            }
            else if ( shopManager.muscle < 10)
            {
                float diff = 10 -  shopManager.muscle;
                 shopManager.muscle += diff;
                 shopManager.fat -= diff;
            }

            // Ensure energy is within range (0, 100)
            if ( shopManager.energy > 100)
            {
                float diff =  shopManager.energy - 100;
                 shopManager.energy -= diff;
            }

        // Αποθήκευση των ενημερωμένων τιμών
        PlayerPrefs.SetFloat("PlayerCoins", shopManager.coins);
        PlayerPrefs.SetFloat("Fat", shopManager.fat);
        PlayerPrefs.SetFloat("Muscle", shopManager.muscle);
        PlayerPrefs.SetFloat("Energy", shopManager.energy);
        PlayerPrefs.Save();

        // Ενημέρωση του UI
        shopManager.Coinstxt.text = "Coins: " + shopManager.coins.ToString();

        // Προετοιμασία δεδομένων για αποθήκευση σε αρχείο κειμένου
        string dataPath = Application.persistentDataPath + "/UserData.txt";
        string dateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        string data = $"Date and Time: {dateTime}\n" +
                      $"Muscle: {shopManager.muscle}\n" +
                      $"Coins: {shopManager.coins}\n" +
                      $"Fat: {shopManager.fat}\n" +
                      $"Energy: {shopManager.energy}\n\n";

        // Προσθήκη των δεδομένων στο αρχείο
        System.IO.File.AppendAllText(dataPath, data);
    }
}
