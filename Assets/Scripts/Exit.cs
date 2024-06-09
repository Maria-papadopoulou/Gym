using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    // Αυτή η μέθοδος θα κληθεί όταν ο χρήστης πατήσει "Yes"
    public void YesButton()
    {
         // Κλείσιμο της εφαρμογής
        Application.Quit();

        // Αυτό είναι απαραίτητο για να κλείσει η εφαρμογή όταν τρέχει στο Unity Editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    // Αυτή η μέθοδος θα κληθεί όταν ο χρήστης πατήσει "No"
    public void NoButton()
    {
        // Επιστροφή στην προηγούμενη σκηνή
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
       
    }
}

 
