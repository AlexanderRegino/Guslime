using System.Collections;
using UnityEngine;

public class CheckForSnow : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        // Check if the current level is not "Snow"
        if (PlayerPrefs.GetString("CurrentLevel") != "Snow")
        {
            // Disable the particle emitter if the level is not "Snow"
            DisableParticleEmitter();
        }
    }

    void DisableParticleEmitter()
    {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            particleSystem.Stop(); // Stop emitting particles
            gameObject.SetActive(false); // Disable the entire GameObject
        }
        else
        {
            Debug.LogError("Particle System component not found!");
        }
    }
}
