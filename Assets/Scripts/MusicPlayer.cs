using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;  // Use camelCase for public fields
    private float musicVolume = 1.0f;

    void Start()
    {
        audioSource.Play();
    }

    void Update()
    {
        audioSource.volume = musicVolume;  // Correct property name
    }

    public void UpdateVolume(float volume)  // Use PascalCase for method names
    {
        musicVolume = volume;
    }
}
