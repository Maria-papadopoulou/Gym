using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    int minutes;
    int seconds;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        minutes = Mathf.FloorToInt(elapsedTime / 60);
        seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Έλεγχος αν τα δευτερόλεπτα είναι πολλαπλάσιο του 3
        if (seconds % 3 == 0 && seconds != 0)
        {
            timerText.color = Color.red; // Κάνουμε το χρώμα κόκκινο
        }
        else
        {
            timerText.color = Color.white; // Κάνουμε το χρώμα λευκό
        }
    }
}
