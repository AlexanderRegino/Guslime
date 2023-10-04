using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // You need this for UI text
using TMPro;

public class pointsManager : MonoBehaviour
{
    public static pointsManager instance;
    public TMP_Text pointText;
    public int currentPoints = 0;

    public AudioSource collectSound;
    // Function to update the UI text with the current score
    void UpdateScoreText()
    {
        Debug.Log("Entering UpdateScoreText Function");
        if (pointText != null)
        {
            Debug.Log("Point Text is NOT NULL");
            pointText.text = "Score: " + currentPoints.ToString();
        }
    
    }


    // Awake is called before any Start function
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Public function to update the points
    public void UpdatePoints(int pointsToAdd)
    {

        Debug.Log("Points from Function");
        currentPoints += pointsToAdd; // Increment the points
        collectSound.Play();
        UpdateScoreText();
    }
}
