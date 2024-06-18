using UnityEngine;
using TMPro;
using DialogueEditor; // Make sure you have this if you're using Dialogue Editor for conversations

public class DietitianInteraction : MonoBehaviour
{
    public Transform player;
    public Transform Suzie;
    public Canvas interactionCanvas;
    public TextMeshProUGUI interactionText;
    public TextMeshProUGUI keyText;
    public NPCConversation myConversation;
    public GameObject cameraHolder; // Reference to the CameraHolder GameObject

    private bool isNearSuzie = false;
    private ConversationStarter conversationStarter;
    private PlayerCam playerCam;

    void Start()
    {
        if (interactionCanvas != null)
        {
            interactionCanvas.enabled = false; // Hide the interaction UI initially
        }
        else
        {
            Debug.LogError("Interaction Canvas is not assigned.");
        }

        if (Suzie != null)
        {
            // Try to get the ConversationStarter component from Suzie GameObject
            conversationStarter = Suzie.GetComponent<ConversationStarter>();

            if (conversationStarter == null)
            {
                Debug.LogError("ConversationStarter component is not found on Suzie.");
            }
        }
        else
        {
            Debug.LogError("Suzie Transform is not assigned.");
        }

        if (cameraHolder != null)
        {
            // Try to get the PlayerCam component from the CameraHolder GameObject
            playerCam = cameraHolder.GetComponentInChildren<PlayerCam>();

            if (playerCam == null)
            {
                Debug.LogError("PlayerCam component is not found in the CameraHolder.");
            }
        }
        else
        {
            Debug.LogError("CameraHolder GameObject is not assigned.");
        }
    }

    void Update()
    {
        // Check the distance between the player and Suzie
        float distance = Vector3.Distance(player.position, Suzie.position);

        // If the player is close enough to Suzie
        if (distance < 5.0f)
        {
            isNearSuzie = true;
            if (interactionCanvas != null)
            {
                interactionCanvas.enabled = true; // Show the interaction UI
                keyText.text = "E";
                interactionText.text = "Press E to talk";
            }
        }
        else
        {
            isNearSuzie = false;
            if (interactionCanvas != null)
            {
                interactionCanvas.enabled = false; // Hide the interaction UI
            }
        }

        // Check if the player presses 'E'
        if (isNearSuzie && Input.GetKeyDown(KeyCode.E))
        {
            ShowInteractionMessage();
        }
    }

    void ShowInteractionMessage()
    {
        if (player != null)
        {
            // Disable PlayerMovement script
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }
            else
            {
                Debug.LogError("PlayerMovement script not found on Player.");
            }
        }

        if (playerCam != null)
        {
            playerCam.enabled = false; // Disable the PlayerCam script
        }

        if (interactionCanvas != null)
        {
            interactionCanvas.enabled = false; // Hide the interaction UI
        }

        if (conversationStarter != null && myConversation != null)
        {
            // Start the conversation
            conversationStarter.Resume(myConversation);
        }
        else
        {
            if (conversationStarter == null)
            {
                Debug.LogError("ConversationStarter component is not found on Suzie.");
            }
            if (myConversation == null)
            {
                Debug.LogError("myConversation is not assigned.");
            }
        }
    }

    public void unblockMovement()
    {
        if (player != null)
        {
            // Enable PlayerMovement script
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.enabled = true;
            }
            else
            {
                Debug.LogError("PlayerMovement script not found on Player.");
            }
        }

        if (playerCam != null)
        {
            playerCam.enabled = true; // Enable the PlayerCam script
        }

        if (interactionCanvas != null)
        {
            interactionCanvas.enabled = true; // Show the interaction UI
        }
    }
}
