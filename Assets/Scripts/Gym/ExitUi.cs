using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitUi : MonoBehaviour
{
    public Transform player;
    public GameObject cameraHolder; // Reference to the CameraHolder GameObject

    private PlayerCam playerCam;
    public Canvas interactionCanvas;

    void Start()
    {
        if (cameraHolder != null)
        {
            playerCam = cameraHolder.GetComponent<PlayerCam>();
            if (playerCam == null)
            {
                Debug.LogError("PlayerCam script not found on CameraHolder.");
            }
        }
        else
        {
            Debug.LogError("CameraHolder GameObject is not assigned.");
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
        else
        {
            Debug.LogError("PlayerCam script is not assigned or not found.");
        }

        if (interactionCanvas != null)
        {
            interactionCanvas.enabled = false; // Hide the interaction UI
        }
        else
        {
            Debug.LogError("Interaction Canvas is not assigned.");
        }
    }
}
