using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public GameObject ObjectMusic;

    private AudioSource audioSource;
    private float musicVolume = 1f;

    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("gamemusic");
        audioSource = ObjectMusic.GetComponent<AudioSource>();
        musicVolume = PlayerPrefs.GetFloat("musicVolume", 1.0f); // Load saved volume or default to 1.0f
        audioSource.volume = musicVolume;
    }

    void Update()
    {
        audioSource.volume = musicVolume; // Update the AudioSource volume
    }

    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
        PlayerPrefs.SetFloat("musicVolume", musicVolume); // Save the current volume
        PlayerPrefs.Save();
    }
}
