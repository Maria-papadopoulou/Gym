using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionScript : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;

    private void Start() {
        int savedIndex = PlayerPrefs.GetInt("CharacterSelected", 0); // Default to 0 if not set
        characterList = new GameObject[transform.childCount];

        // Populate the characterList array with child GameObjects
        for (int i = 0; i < transform.childCount; i++) {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        // Ensure all characters are initially inactive
        foreach (GameObject go in characterList) {
            if (go != null) {
                go.SetActive(false);
            }
        }

        // Validate the saved index
        if (savedIndex >= 0 && savedIndex < characterList.Length) {
            index = savedIndex;
        } else {
            index = 0; // Fallback to a valid index
        }

        // Activate the selected character
        if (characterList.Length > 0 && characterList[index] != null) {
            characterList[index].SetActive(true);
        } else {
            Debug.LogWarning("No characters available to select.");
        }
    }

    public void ToggleLeft() {
        if (characterList.Length == 0) return;

        characterList[index].SetActive(false);
        index--;
        if (index < 0) {
            index = characterList.Length - 1;
        }
        characterList[index].SetActive(true);
    }

    public void ToggleRight() {
        if (characterList.Length == 0) return;

        characterList[index].SetActive(false);
        index++;
        if (index >= characterList.Length) {
            index = 0;
        }
        characterList[index].SetActive(true);
    }

    public void ConfirmButton() {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("Game");
    }
}
