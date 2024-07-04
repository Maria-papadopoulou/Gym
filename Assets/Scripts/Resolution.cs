using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private int defaultWidth = 1920;
    private int defaultHeight = 1080;

    void Start()
    {
        // Initialize dropdown
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(new List<string> {
            "1366x768", "1600x900", "1920x720", "1920x1080", "1920x1200", "2560x1440", "2560x1600"
        });

        // Load saved resolution or set default
        LoadResolution();

        // Listen to dropdown value changes
        resolutionDropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(resolutionDropdown); });
    }

    // Method to set resolution based on dropdown selection
    public void SetResolution(int width, int height)
    {
        Screen.SetResolution(width, height, FullScreenMode.Windowed);
        Debug.Log($"Resolution set to {width}x{height}");

        // Save selected resolution to PlayerPrefs
        PlayerPrefs.SetInt("ScreenWidth", width);
        PlayerPrefs.SetInt("ScreenHeight", height);
    }

    // Called when dropdown value changes
    void DropdownValueChanged(TMP_Dropdown change)
    {
        int index = change.value;
        switch (index)
        {
            case 0: SetResolution(1366, 768); break;
            case 1: SetResolution(1600, 900); break;
            case 2: SetResolution(1920, 720); break;
            case 3: SetResolution(1920, 1080); break;
            case 4: SetResolution(1920, 1200); break;
            case 5: SetResolution(2560, 1440); break;
            case 6: SetResolution(2560, 1600); break;
            default: break;
        }
    }

    // Load saved resolution from PlayerPrefs
    void LoadResolution()
    {
        int savedWidth = PlayerPrefs.GetInt("ScreenWidth", defaultWidth);
        int savedHeight = PlayerPrefs.GetInt("ScreenHeight", defaultHeight);
        SetResolution(savedWidth, savedHeight);

        // Set dropdown value to match loaded resolution
        switch ($"{savedWidth}x{savedHeight}")
        {
            case "1366x768": resolutionDropdown.value = 0; break;
            case "1600x900": resolutionDropdown.value = 1; break;
            case "1920x720": resolutionDropdown.value = 2; break;
            case "1920x1080": resolutionDropdown.value = 3; break;
            case "1920x1200": resolutionDropdown.value = 4; break;
            case "2560x1440": resolutionDropdown.value = 5; break;
            case "2560x1600": resolutionDropdown.value = 6; break;
            default: break;
        }
    }

    // Method called when "Done" button is clicked
    public void OnDoneButtonClicked()
    {
        int selectedValue = resolutionDropdown.value;
        DropdownValueChanged(resolutionDropdown); // Apply the selected resolution

        // Optionally, you can add additional actions here when "Done" is clicked
    }
}
