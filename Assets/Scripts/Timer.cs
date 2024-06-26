using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] Button toggleButton;
    float elapsedTime;
    int minutes;
    int seconds;
    bool isRunning = true; // Αρχικά το χρονόμετρο είναι ενεργό

    void Start()
    {

        // Αρχικά κλειδώνουμε τον κέρσορα για να είναι πάντα ορατός
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Αρχικοποίηση του χρονόμετρου και εμφάνιση του στο UI
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();

            // Έλεγχος και αλλαγή χρώματος κειμένου κάθε 3 δευτερόλεπτα
            UpdateTextColor();
        }
    }

    void UpdateTimerDisplay()
    {
        minutes = Mathf.FloorToInt(elapsedTime / 60);
        seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void UpdateTextColor()
    {
        if (seconds % 3 == 0 && seconds != 0)
        {
            timerText.color = Color.red;
        }
        else
        {
            timerText.color = Color.white;
        }
    }
}