using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyBar : MonoBehaviour
{
    [Header("UI Elements")]
    public Image energyBarFill; // The Image component that represents the fill of the energy bar
    public TMP_Text energyText; // The TextMeshPro component to display the current energy

    [Header("Settings")]
    public float maxEnergy = 100f; // The maximum energy value

    private float currentEnergy;

    void Start()
    {
        LoadEnergy();
        UpdateEnergyBar();
    }

    void LoadEnergy()
    {
        // Load the energy value from PlayerPrefs
        currentEnergy = PlayerPrefs.GetFloat("Energy", maxEnergy); // Default to maxEnergy if not found
    }

    void UpdateEnergyBar()
    {
        // Update the energy bar fill amount
        if (energyBarFill != null)
        {
            energyBarFill.fillAmount = currentEnergy / maxEnergy;
        }

        // Update the energy text
        if (energyText != null)
        {
            energyText.text = currentEnergy.ToString();
        }

        // Update the status text (optional)
       
    }

    // You can call this method to update the energy bar if the energy value changes during the game
    public void SetEnergy(float newEnergy)
    {
        currentEnergy = Mathf.Clamp(newEnergy, 0, maxEnergy);
        PlayerPrefs.SetFloat("Energy", currentEnergy);
        UpdateEnergyBar();
    }
}
