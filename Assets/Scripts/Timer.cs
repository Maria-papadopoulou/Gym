using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class Timer : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI timerText;
   float elapsedTime;
   int minutes;
   int seconds;

    // Update is called once per frame
    void Update()
    {
        elapsedTime+= Time.deltaTime;
        minutes = Mathf.FloorToInt(elapsedTime / 60);
        seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}",minutes, seconds);
    }
}
