using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource criticalAudioSource;
    [SerializeField] private AudioSource normalHitAudioSource;
    //[SerializeField] private AudioSource normalHitAudioSource;
    // Unity Events for critical and normal hit actions
    public UnityEvent onCriticalHit;
    public UnityEvent onNormalHit;

    private void Awake()
    {
        // If AudioSources are not assigned in the inspector, try to get them dynamically
        if (criticalAudioSource == null)
        {
            criticalAudioSource = GetComponent<AudioSource>();
        }

        if (normalHitAudioSource == null)
        {
            normalHitAudioSource = GetComponent<AudioSource>();
        }
    }

    // Use these audio sources and Unity Events as needed in the rest of your script

    // Example usage:
    public void PlayCriticalSound()
    {
        if (criticalAudioSource != null)
        {
            criticalAudioSource.Play();

            // Trigger the Unity Event for critical hit
            //onCriticalHit.Invoke();
        }
    }

    public void PlayNormalHitSound()
    {
        if (normalHitAudioSource != null)
        {
            normalHitAudioSource.Play();
            // Trigger the Unity Event for normal hit
            //onNormalHit.Invoke();
        }
    }
}
