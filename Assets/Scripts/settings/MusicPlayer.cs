using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public GameObject ObjectMusic;

    private AudioSource audioSource;  // Use camelCase for private fields
    private float musicVolume = 1f;

    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("gamemusic");
        audioSource = ObjectMusic.GetComponent<AudioSource>();

        // Load the saved volume
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("musicVolume");
            audioSource.volume = musicVolume;
        }
        else
        {
            musicVolume = 1.0f; // Default volume if no saved value exists
        }
    }

    private void Update()
    {
        audioSource.volume = musicVolume;  // Correct property name
    }

    public void UpdateVolume(float volume)  // Use PascalCase for method names
    {
        musicVolume = volume;
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.Save();  // Ensure the volume is saved
    }
}
