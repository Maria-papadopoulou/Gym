using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public Transform player;
    public Transform megan;
    public Canvas interactionCanvas;
    public TextMeshProUGUI interactionText;
    public TextMeshProUGUI keyText;

    private bool isNearMegan = false;

    void Start()
    {
        interactionCanvas.enabled = false; // Hide the interaction UI initially
    }

    void Update()
    {
        // Check the distance between the player and Megan
        float distance = Vector3.Distance(player.position, megan.position);

        // If the player is close enough to Megan
        if (distance < 3.0f)
        {
            isNearMegan = true;
            interactionCanvas.enabled = true; // Show the interaction UI
            keyText.text = "E";
            interactionText.text = "Press E to talk";
        }
        else
        {
            isNearMegan = false;
            interactionCanvas.enabled = false; // Hide the interaction UI
        }

        // Check if the player presses 'E'
        if (isNearMegan && Input.GetKeyDown(KeyCode.E))
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
