using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BackTimer2 : MonoBehaviour
{
    private float startTime;
    private float elapsedTime;
    public TextMeshProUGUI timerText; // Αναφορά στο UI Text για εμφάνιση του χρονόμετρου
    public Button startButton; // Κουμπί έναρξης
    public Button stopButton; // Κουμπί διακοπής
    public bool isRunning = false; // Αρχικά το χρονόμετρο δεν είναι ενεργό
    public float coins;
    public float fat;
    public float muscle;
    public float energy;

 private float lastUpdateTime; // Variable to track the last time stats were updated
    void Start()
    {
        // Αρχικά κλειδώνουμε τον κέρσορα για να είναι πάντα ορατός
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Αρχικοποίηση του χρονόμετρου και εμφάνιση του στο UI
        UpdateTimerDisplay(0);

        // Σύνδεση των κουμπιών με τις αντίστοιχες μεθόδους
        startButton.onClick.AddListener(TimerStart);
        stopButton.onClick.AddListener(TimerStop);
        // fetch
        coins = PlayerPrefs.GetFloat("PlayerCoins");
        fat=PlayerPrefs.GetFloat("Fat");
        muscle=PlayerPrefs.GetFloat("Muscle");
        energy=PlayerPrefs.GetFloat("Energy");
        lastUpdateTime = 0; // Initialize the last update time
    }

    public void TimerStart()
    {
        if (!isRunning)
        {
            print("START");
            isRunning = true;
            startTime = Time.time - elapsedTime; // Συνέχιση από τον χρόνο που σταμάτησε
            Debug.Log("Timer started at: " + startTime);
        }
    }

    public void TimerStop()
    {
        if (isRunning)
        {
            print("STOP");
            isRunning = false;
            elapsedTime = Time.time - startTime; // Αποθήκευση του χρόνου που έχει περάσει
            Debug.Log("Timer stopped at: " + elapsedTime);
        }
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime = Time.time - startTime;
            UpdateTimerDisplay(elapsedTime);
            UpdateTextColor(elapsedTime);
            // Check if 3 seconds have passed since the last update
            if (Time.time - lastUpdateTime >= 3)
            {
                UpdatePlayerStats();
                lastUpdateTime = Time.time; // Update the last update time
            }
        }
    }

    void UpdateTimerDisplay(float elapsedTime)
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

      void UpdateTextColor(float elapsedTime)
    {
        int remainder = Mathf.FloorToInt(elapsedTime) % 4;

        if (remainder == 0)
        {
            timerText.color = Color.white;
        }
        else if (remainder >= 1 && remainder <= 3)
        {
            timerText.color = Color.red;
        }
    }

    void UpdatePlayerStats()
    {
        // Αύξηση των coins κατά 2
        coins += 2;
        // Μείωση του fat κατά 5
        fat -= 5;
        muscle += 5;
        energy-=5;


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
                      $"Back2\n" +
                      $"Muscle: {muscle}\n" +
                      $"Coins: {coins}\n" +
                      $"Fat: {fat}\n" +
                      $"Energy: {energy}\n\n";

        // Προσθήκη των δεδομένων στο αρχείο
        System.IO.File.AppendAllText(dataPath, data);
    }

}
