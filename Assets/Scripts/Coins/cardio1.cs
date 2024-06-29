using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatsUpdater : MonoBehaviour
{
    private Timer timer;
    public float coins;
    public float fat;
    public float muscle;
    public float energy;
    private float updateInterval = 3f; // Διάστημα ενημέρωσης σε δευτερόλεπτα

    void Start()
    {
        // Βρες το Timer και το ShopManager script στο ίδιο GameObject ή στην σκηνή
        timer = FindObjectOfType<Timer>();

        // Ξεκίνα το coroutine που θα ενημερώνει τα στατιστικά του παίκτη
        StartCoroutine(UpdatePlayerStatsCoroutine());
        // fetch
        coins = PlayerPrefs.GetFloat("PlayerCoins");
        fat=PlayerPrefs.GetFloat("Fat");
        muscle=PlayerPrefs.GetFloat("Muscle");
        energy=PlayerPrefs.GetFloat("Energy");
    }

    IEnumerator UpdatePlayerStatsCoroutine()
    {
        while (true)
        {
            // Περίμενε για το καθορισμένο διάστημα
            yield return new WaitForSeconds(updateInterval);

            // Αν το χρονόμετρο τρέχει, ενημέρωσε τα στατιστικά του παίκτη
            if (timer != null && timer.isRunning)
            {
                UpdatePlayerStats();
            }
        }
    }

    void UpdatePlayerStats()
    {
        // Αύξηση των coins κατά 2
        coins += 2;
        // Μείωση του fat κατά 5
        fat -= 5;
        muscle += 5;
        energy+=5;


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
        else if (energy < 0)
        {
            float diff = 0 - energy;
            energy += diff;
        }

        // Αποθήκευση των ενημερωμένων τιμών
        PlayerPrefs.SetFloat("PlayerCoins", coins);
        PlayerPrefs.SetFloat("Fat", fat);
        PlayerPrefs.SetFloat("Muscle", muscle);
        PlayerPrefs.SetFloat("Energy", energy);
        PlayerPrefs.Save();

        // Ενημέρωση του UI

        // Προετοιμασία δεδομένων για αποθήκευση σε αρχείο κειμένου
        string dataPath = Application.persistentDataPath + "/UserData.txt";
        string dateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        string data = $"Date and Time: {dateTime}\n" +
                      $"Cardio1\n" +
                      $"Muscle: {muscle}\n" +
                      $"Coins: {coins}\n" +
                      $"Fat: {fat}\n" +
                      $"Energy: {energy}\n\n";

        // Προσθήκη των δεδομένων στο αρχείο
        System.IO.File.AppendAllText(dataPath, data);
    }
}
