using UnityEngine;
using TMPro;

public class DietitianInteraction : MonoBehaviour
{
    public Transform player;
    public Transform Suzie;
    public Canvas interactionCanvas;
    public TextMeshProUGUI interactionText;
    public TextMeshProUGUI keyText;

    private bool isNearSuzie = false;

    void Start()
    {
        interactionCanvas.enabled = false; // Hide the interaction UI initially
    }

    void Update()
    {
        // Check the distance between the player and Suzie
        float distance = Vector3.Distance(player.position, Suzie.position);

        // If the player is close enough to Suzie
        if (distance < 5.0f)
        {
            isNearSuzie = true;
            interactionCanvas.enabled = true; // Show the interaction UI
            keyText.text = "E";
            interactionText.text = "Press E to talk";
        }
        else
        {
            isNearSuzie = false;
            interactionCanvas.enabled = false; // Hide the interaction UI
        }

        // Check if the player presses 'E'
        if (isNearSuzie && Input.GetKeyDown(KeyCode.E))
        {
            // Perform the interaction, e.g., show a message
            ShowInteractionMessage();
        }
    }

    void ShowInteractionMessage()
    {
        // Show a message or perform any action
        interactionText.text = "Hello!";
        // Optionally, hide the key prompt
        keyText.text = "";
    }
}
