using System.Collections;
using UnityEngine;

public class playMusic : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource backgroundMusicSnow;
    [SerializeField] AudioSource backgroundMusicGrass;

    void Start()
    {
        // Get the current level from PlayerPrefs
        string currentLevel = PlayerPrefs.GetString("CurrentLevel", "Basic");

        // Play the background music based on the current level
        PlayBackgroundMusic(currentLevel);
    }

    void PlayBackgroundMusic(string level)
    {
        // Stop all audio sources initially
        backgroundMusic.Stop();
        backgroundMusicSnow.Stop();
        backgroundMusicGrass.Stop();

        // Play the appropriate background music based on the level
        if (level == "Basic")
        {
            backgroundMusic.Play();
        }
        else if (level == "Snow")
        {
            backgroundMusicSnow.Play();
        }
        else if (level == "Grass")
        {
            backgroundMusicGrass.Play();
        }
    }
}
