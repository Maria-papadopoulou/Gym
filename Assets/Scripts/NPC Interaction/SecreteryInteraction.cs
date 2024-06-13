using UnityEngine;
using TMPro;

public class SecreteryInteraction : MonoBehaviour
{
    public Transform player;
    public Transform Secretary;
    public Canvas interactionCanvas;
    public TextMeshProUGUI interactionText;
    public TextMeshProUGUI keyText;

    private bool isNearSecretary = false;

    void Start()
    {
        interactionCanvas.enabled = false; // Hide the interaction UI initially
    }

    void Update()
    {
        // Check the distance between the player and Secretary
        float distance = Vector3.Distance(player.position, Secretary.position);

        // If the player is close enough to Secretary
        if (distance < 5.0f)
        {
            isNearSecretary = true;
            interactionCanvas.enabled = true; // Show the interaction UI
            keyText.text = "E";
            interactionText.text = "Press E to talk";
        }
        else
        {
            isNearSecretary = false;
            interactionCanvas.enabled = false; // Hide the interaction UI
        }

        // Check if the player presses 'E'
        if (isNearSecretary && Input.GetKeyDown(KeyCode.E))
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
