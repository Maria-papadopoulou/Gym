using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TeleportScript : MonoBehaviour
{
    public Canvas videoCanvas; // Βάλε το Canvas από το Inspector
    public VideoPlayer videoPlayer; // Βάλε το Video Player από το Inspector

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Ελέγχει αν πατήθηκε το αριστερό κουμπί του ποντικιού
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform) // Ελέγχει αν το αντικείμενο που πατήθηκε είναι το ίδιο
                {
                    OpenCanvas();
                }
            }
        }
    }

    void OpenCanvas()
    {
        // Ενεργοποίηση του Canvas
        videoCanvas.enabled = true;

        // Έναρξη του βίντεο
        videoPlayer.Play();
    }
}
