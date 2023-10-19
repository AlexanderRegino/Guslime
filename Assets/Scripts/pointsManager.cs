using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // You need this for UI text
using TMPro;

public class pointsManager : MonoBehaviour
{
    public static pointsManager instance;
    public TMP_Text pointText;
    public TMP_Text levelText;
    public int currentPoints = 0;
    public int currentLevel = 0;
    public float requestCooldown = 2.0f; // Initial requestCooldown value
    public float ProjectileSpeed = 5.0f; // Initial ProjectileSpeed value
    public AudioSource collectSound;
    public GameObject shotgunProjectilePrefab;
    void UpdateScoreText()
    {
        if (pointText != null)
        {
            pointText.text = "Score: " + currentPoints.ToString();
        }
    }

    void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + currentLevel.ToString();
        }
    }

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

    void Start()
    {
        UpdateScoreText();
        UpdateLevelText();
    }

    // Public function to update the points
    public void UpdatePoints(int pointsToAdd)
    {
        Debug.Log("Points from Function");
        currentPoints += pointsToAdd; // Increment the points
        collectSound.Play();
        UpdateScoreText();

        int previousLevel = currentLevel; // Store the previous level to compare with the new level.

        // Check the experience against thresholds using if-else statements
        if (currentPoints >= 100)
        {
            Debug.Log("Reached 100 XP!");
            currentLevel = 8;
        }
        else if (currentPoints >= 70)
        {
            Debug.Log("Reached 70 XP!");
            currentLevel = 7;
        }
        else if (currentPoints >= 50)
        {
            Debug.Log("Reached 50 XP!");
            currentLevel = 6;
        }
        else if (currentPoints >= 30)
        {
            Debug.Log("Reached 30 XP!");
            currentLevel = 5;
        }
        else if (currentPoints >= 20)
        {
            Debug.Log("Reached 20 XP!");
            currentLevel = 4;
        }
        else if (currentPoints >= 10)
        {
            Debug.Log("Reached 10 XP!");
            currentLevel = 3;
        }
        else if (currentPoints >= 6)
        {
            Debug.Log("Reached 6 XP!");
            currentLevel = 2;
        }
        else if (currentPoints >= 3)
        {
            Debug.Log("Reached 3 XP!");
            currentLevel = 1;
        }

        if (currentLevel != previousLevel)
        {
            // Update the requestCooldown and ProjectileSpeed based on the new level.
            UpdateRequestCooldown();
            UpdateProjectileSpeed();
        }

        UpdateLevelText();
    }

    // Function to update requestCooldown based on the current level.
    void UpdateRequestCooldown()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Player playerScript = player.GetComponent<Player>();

            if (playerScript != null)
            {
                switch (currentLevel)
                {
                    case 1:
                        playerScript.requestCooldown = 0.8f;
                        break;
                    case 2:
                        playerScript.requestCooldown = 0.6f;
                        break;
                    case 3:
                        playerScript.requestCooldown = 0.2f;
                        break;
                    case 4:
                        playerScript.requestCooldown = 0.1f;
                        break;
                    case 5:
                        playerScript.requestCooldown = 1f;
                        break;
                    case 6:
                        playerScript.requestCooldown = .8f;
                        break;
                    case 7:
                        playerScript.requestCooldown = .4f;
                        break;
                    case 8:
                        playerScript.requestCooldown = .2f;
                        break;
                }
            }
        }
    }


    // Function to update ProjectileSpeed based on the current level.
    void UpdateProjectileSpeed()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Player playerScript = player.GetComponent<Player>();

            if (playerScript != null)
            {
                switch (currentLevel)
                {
                    case 1:
                        playerScript.ProjectileSpeed = 6.0f;
                        break;
                    case 2:
                        playerScript.ProjectileSpeed = 7.0f;
                        break;
                    case 3:
                        playerScript.ProjectileSpeed = 8.0f;
                        break;
                    case 4:
                        playerScript.ProjectileSpeed = 10.0f;
                        break;
                    case 5:
                        playerScript.ProjectileSpeed = 6f;
                        playerScript.currentProjectilePrefab = shotgunProjectilePrefab; // Set the projectile to shotgunPrefab
                        break;
                    case 6:
                        playerScript.ProjectileSpeed = 7f;
                        break;
                    case 7:
                        playerScript.ProjectileSpeed = 8f;
                        break;
                    case 8:
                        playerScript.ProjectileSpeed = 10f;
                        break;
                }
            }
        }
    }

}
