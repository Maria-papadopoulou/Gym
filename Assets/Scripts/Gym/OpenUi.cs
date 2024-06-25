using System.Collections;
using UnityEngine;

public class OpenUi : MonoBehaviour
{
    public Canvas interactionCanvas;
    public Transform player;
    public GameObject cameraHolder; // Reference to the CameraHolder GameObject
    private PlayerCam playerCam;


    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Teleporter());
    }

    IEnumerator Teleporter()
    {
        
        // Disable PlayerMovement script
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.enabled = false;
        playerCam = cameraHolder.GetComponentInChildren<PlayerCam>();
        playerCam.enabled = false; // Disable the PlayerCam script
        yield return new WaitForSeconds(0); // Wait for 1 second (optional)
        interactionCanvas.enabled = true; // Enable the canvas
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
