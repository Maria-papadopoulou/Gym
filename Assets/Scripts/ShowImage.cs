using UnityEngine;
using UnityEngine.UI;

public class ShowImage : MonoBehaviour
{
    public GameObject instructionsImage; // Drag and drop your InstructionsImage GameObject here in the Inspector

    public void ToggleImage()
    {
        // Toggle the active state of the instructions image
        instructionsImage.SetActive(!instructionsImage.activeSelf);
    }
}
