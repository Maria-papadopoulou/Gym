using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void Exit_button() 
   {
        Application.Quit();
        SceneManager.LoadScene("Exit");

   }
     public void Settings_button()
   {
        SceneManager.LoadScene("Settings");
   }
   public void Start_game()
   {
        SceneManager.LoadScene("Character Selection");
   }
}
