using UnityEngine;
using TMPro;
using DialogueEditor;

public class SecretaryInteraction : MonoBehaviour
{
    public Transform player;
    public Transform secretary;
    public Canvas interactionCanvas;
    public TextMeshProUGUI interactionText;
    public TextMeshProUGUI keyText;
    public NPCConversation myConversation;

    private bool isNearSecretary = false;
    private ConversationStarter conversationStarter;

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

        if (secretary != null)
        {
            // Try to get the ConversationStarter component from the secretary GameObject
            conversationStarter = secretary.GetComponent<ConversationStarter>();

            if (conversationStarter == null)
            {
                Debug.LogError("ConversationStarter component is not found on the Secretary.");
            }
        }
        else
        {
            Debug.LogError("Secretary Transform is not assigned.");
        }
    }

    void Update()
    {
        // Check the distance between the player and secretary
        if (secretary != null)
        {
            float distance = Vector3.Distance(player.position, secretary.position);

            // If the player is close enough to the secretary
            if (distance < 5.0f)
            {
                isNearSecretary = true;
                if (interactionCanvas != null)
                {
                    interactionCanvas.enabled = true; // Show the interaction UI
                    keyText.text = "E";
                    interactionText.text = "Press E to talk";
                }
            }
            else
            {
                isNearSecretary = false;
                if (interactionCanvas != null)
                {
                    interactionCanvas.enabled = false; // Hide the interaction UI
                }
            }

            // Check if the player presses 'E'
            if (isNearSecretary && Input.GetKeyDown(KeyCode.E))
            {
                ShowInteractionMessage();
            }
        }
    }

    void ShowInteractionMessage()
    {
        if (conversationStarter != null && myConversation != null)
        {
            // Use the ConversationManager to start the conversation
            conversationStarter.Resume(myConversation);
        }
        else
        {
            if (conversationStarter == null)
            {
                Debug.LogError("ConversationStarter component is not found on the Secretary.");
            }
            if (myConversation == null)
            {
                Debug.LogError("myConversation is not assigned.");
            }
        }
    }
}
