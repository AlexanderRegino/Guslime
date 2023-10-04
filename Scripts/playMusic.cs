using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMusic : MonoBehaviour
{
     [SerializeField] AudioSource backgroundMusic;

     void Start()
    {
        backgroundMusic.Play();
    }
}
