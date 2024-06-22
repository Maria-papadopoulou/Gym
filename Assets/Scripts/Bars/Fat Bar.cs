using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FatBar : MonoBehaviour
{
    [Header("UI Elements")]
    public Image fatBarFill; // The Image component that represents the fill of the fat bar
    public TMP_Text fatText; // The TextMeshPro component to display the current fat value

    [Header("Settings")]
    public float maxFat = 100f; // The maximum fat value

    private float currentFat;

    void Start()
    {
        LoadFat();
        UpdateFatBar();
    }

    private void Update() {
        LoadFat();
        UpdateFatBar();
    }

    void LoadFat()
    {
        // Load the fat value from PlayerPrefs
        currentFat = PlayerPrefs.GetFloat("Fat", maxFat); // Default to maxFat if not found

    }

    void UpdateFatBar()
    {
        // Update the fat bar fill amount
        if (fatBarFill != null)
        {
            fatBarFill.fillAmount = currentFat / maxFat;
        }

        // Update the fat text
        if (fatText != null)
        {
            fatText.text = currentFat.ToString();
        }

        
    }

}
