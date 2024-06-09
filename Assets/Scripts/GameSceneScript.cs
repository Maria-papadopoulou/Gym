using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneScript : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;

    private void Start() {
        index = PlayerPrefs.GetInt("CharacterSelected", 0); // Default to 0 if not set
        characterList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++) {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in characterList) {
            if (go != null) {
                go.SetActive(false);
            }
        }

        if (characterList.Length > 0 && characterList[index] != null) {
            characterList[index].SetActive(true);
        }
    }
}
