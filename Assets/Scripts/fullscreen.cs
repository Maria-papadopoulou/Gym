using UnityEngine;
using UnityEngine.UI;

public class FullscreenToggle : MonoBehaviour
{
    public Toggle fullscreenToggle; // Reference to your UI toggle button

    private void Start()
    {
        // Retrieve saved fullscreen state from PlayerPrefs
        bool isFullscreen = PlayerPrefs.GetInt("FullscreenState", 0) == 1;
        fullscreenToggle.isOn = isFullscreen;

        // Add an event listener to the toggle button
        fullscreenToggle.onValueChanged.AddListener(ChangeFullscreen);
    }

    public void ChangeFullscreen(bool isFullscreen)
    {
        // Save the current fullscreen state to PlayerPrefs
        PlayerPrefs.SetInt("FullscreenState", isFullscreen ? 1 : 0);

        // Apply fullscreen mode
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen mode changed: " + (isFullscreen ? "On" : "Off"));
    }
}
