using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI sliderText = null;
   [SerializeField] private float maxSliderAmount = 100.0f;
   public void SliderChange(float value)
   {
    float localValue = value * maxSliderAmount;
    sliderText.text = localValue.ToString("0");
   }
}
