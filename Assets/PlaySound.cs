using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] AudioSource DeathSound;

    public void PlayDeathSound()
    {
        DeathSound.Play();
    }
}
