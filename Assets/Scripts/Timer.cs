using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float startTime;
    private float elapsedTime;
    public TextMeshProUGUI timerText; // Αναφορά στο UI Text για εμφάνιση του χρονόμετρου
    public Button startButton; // Κουμπί έναρξης
    public Button stopButton; // Κουμπί διακοπής
    public bool isRunning = false; // Αρχικά το χρονόμετρο δεν είναι ενεργό

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

}
