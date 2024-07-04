using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetQualityLevel : MonoBehaviour
{
    public TMP_Dropdown qualityDropdown;

    void Start()
    {
        // Ensure the dropdown has the correct number of options
        qualityDropdown.ClearOptions();
        List<string> options = new List<string>() { "Very Low", "Low", "Medium", "High", "Very High", "Ultra" };
        qualityDropdown.AddOptions(options);

        // Load the saved quality setting, or default to the first option (Very Low) if none is saved
        int savedQualityLevel = PlayerPrefs.GetInt("QualityLevel", 0); // 0 corresponds to "Very Low"
        qualityDropdown.value = savedQualityLevel;
        qualityDropdown.RefreshShownValue();
    }

    public void ApplyQualitySetting()
    {
        int selectedQualityLevel = qualityDropdown.value;
        QualitySettings.SetQualityLevel(selectedQualityLevel, true);
        Debug.Log($"Graphics set to {qualityDropdown.options[selectedQualityLevel].text}");

        // Save the selected quality setting
        PlayerPrefs.SetInt("QualityLevel", selectedQualityLevel);
        PlayerPrefs.Save();
    }
}
