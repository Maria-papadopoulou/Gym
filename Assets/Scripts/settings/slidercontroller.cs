using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sliderText = null;
    [SerializeField] private Slider volumeSlider; // Reference to the slider
    [SerializeField] private float maxSliderAmount = 100.0f;
    [SerializeField] private MusicPlayer musicPlayer; // Reference to the MusicPlayer script

    private void Start()
    {
        // Set the slider's value based on the saved volume
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 1.0f);
        // Add listener for when the value of the slider changes
        volumeSlider.onValueChanged.AddListener(musicPlayer.UpdateVolume);
    }

    public void SliderChange(float value)
    {
        float localValue = value * maxSliderAmount;
        sliderText.text = localValue.ToString("0");
        musicPlayer.UpdateVolume(value); // Update the volume in MusicPlayer
    }
}
