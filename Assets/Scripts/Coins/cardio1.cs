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
        if (shopManager.fat < 10)
        {
            shopManager.fat = 10;
        }

        // Αύξηση του muscle κατά 5
        shopManager.muscle += 5;
        if (shopManager.muscle > 90)
        {
            shopManager.muscle = 90;
        }

        // Διατήρηση της συνθήκης muscle + fat = 100
        shopManager.fat = 100 - shopManager.muscle;

        // Βεβαιώσου ότι το fat και το muscle παραμένουν στα όρια (10, 90)
        if (shopManager.fat < 10)
        {
            shopManager.fat = 10;
            shopManager.muscle = 90;
        }
        else if (shopManager.fat > 90)
        {
            shopManager.fat = 90;
            shopManager.muscle = 10;
        }

        if (shopManager.muscle < 10)
        {
            shopManager.muscle = 10;
            shopManager.fat = 90;
        }
        else if (shopManager.muscle > 90)
        {
            shopManager.muscle = 90;
            shopManager.fat = 10;
        }

        // Μείωση του energy κατά 5
        shopManager.energy -= 5;
        if (shopManager.energy < 0)
        {
            shopManager.energy = 0;
        }
        else if (shopManager.energy > 100)
        {
            shopManager.energy = 100;
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
