using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MuscleBar : MonoBehaviour
{
    [Header("UI Elements")]
    public Image muscleBarFill; // The Image component that represents the fill of the muscle bar
    public TMP_Text muscleText; // The TextMeshPro component to display the current muscle value

    [Header("Settings")]
    public float maxMuscle = 100f; // The maximum muscle value

    private float currentMuscle;

    void Start()
    {
        LoadMuscle();
        UpdateMuscleBar();
    }

    void LoadMuscle()
    {
        // Load the muscle value from PlayerPrefs
        currentMuscle = PlayerPrefs.GetFloat("Muscle", maxMuscle); // Default to maxMuscle if not found
    }

    void UpdateMuscleBar()
    {
        // Update the muscle bar fill amount
        if (muscleBarFill != null)
        {
            muscleBarFill.fillAmount = currentMuscle / maxMuscle;
        }

        // Update the muscle text
        if (muscleText != null)
        {
            muscleText.text = currentMuscle.ToString();
        }

        // Update the status text (optional)
        
    }

    // You can call this method to update the muscle bar if the muscle value changes during the game
    public void SetMuscle(float newMuscle)
    {
        currentMuscle = newMuscle;
        PlayerPrefs.SetFloat("Muscle", currentMuscle);
        PlayerPrefs.Save();
        Debug.Log("Muscle: " + PlayerPrefs.GetFloat("Muscle"));
        UpdateMuscleBar();
    }
}
