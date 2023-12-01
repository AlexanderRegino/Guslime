using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class requestProjectile : MonoBehaviour
{
    [SerializeField] float requestCooldown = 1.0f; // Time in seconds between requesting projectiles
    [SerializeField] GameObject currentProjectilePrefab;
    [SerializeField] bool CrissCrossPattern;
    [SerializeField] bool BurstFire;
    [SerializeField] bool RandomSpread;
    [SerializeField] bool WaveSpread;
    private GameObject player; // Reference to the player GameObject
    ProjectileThrower projectileThrower;
    private float lastRequestTime;
    public float ProjectileSpeed = 5f;

    public void MultiplyRequestCooldown(float input)
    {
        requestCooldown *= input;
    }

    // ... (your existing variables)

    // New private boolean variable to alternate between patterns
    private bool alternatePattern = false;

    // Variables for testing purposes (adjust as needed)
    private int numberOfProjectilesInSpread = 3;
    private int numberOfProjectilesInBurst = 5;
    private int numberOfProjectilesInWave = 9;
    private float angleIncrement = 45f; // Angle increment for the wave pattern
    private float waveSpreadIncrement = 15f; // Adjust this value based on your desired wave pattern.

    void Awake()
    {
        projectileThrower = GetComponent<ProjectileThrower>();
        player = GameObject.FindGameObjectWithTag("Player"); // Assuming you've tagged the player object with "Player".
    }

    void Update()
    {
        // Check if enough time has passed since the last projectile was requested.
        if (Time.time - lastRequestTime >= requestCooldown && !PauseMenu.isPaused)
        {
            StartCoroutine(RequestProjectiles());
            // Update the last time a projectile was requested.
            lastRequestTime = Time.time;
        }
    }
    private float randomOffsetMagnitude = 2.0f; // Adjust this value based on your desired offset magnitude

    IEnumerator RequestProjectiles()
    {
        if (player != null && gameObject != null) // Check if the player reference is valid
        {
            // Request a projectile aiming at the player's position.
            Vector3 targetPosition = player.transform.position;
            Debug.Log("GameObject is", gameObject);

            if (RandomSpread)
            {
                for (int i = 0; i < numberOfProjectilesInSpread; i++)
                {
                    // Calculate a random offset from the player's position.
                    Vector3 randomOffset = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * randomOffsetMagnitude;

                    // Use the modified target position with the random offset.
                    Vector3 spawnPosition = player.transform.position + randomOffset;

                    // Request the projectile using the modified position.
                    projectileThrower.Throw(currentProjectilePrefab, spawnPosition, gameObject, ProjectileSpeed);
                }
            }
            // Burst Fire
            else if (BurstFire)
            {
                float delayBetweenShots = 0.25f;

                for (int i = 0; i < numberOfProjectilesInBurst; i++)
                {
                    projectileThrower.Throw(currentProjectilePrefab, player.transform.position, gameObject, ProjectileSpeed);

                    // Add a delay between shots.
                    yield return new WaitForSeconds(delayBetweenShots);
                }
            }

            // Custom Projectile Pattern (Wave Spread)
            else if (WaveSpread)
            {
                float waveOffset = 0f;

                // Loop through each projectile in the wave pattern.
                for (int i = 0; i < numberOfProjectilesInWave; i++)
                {
                    // Calculate the angle for the current projectile.
                    float angle = i * angleIncrement + waveOffset;

                    // Calculate the position offset based on the angle.
                    Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f);

                    // Calculate the final position for the projectile.
                    Vector3 projectilePosition = transform.position + offset;

                    // Request the projectile using the original Throw method.
                    projectileThrower.Throw(currentProjectilePrefab, projectilePosition, gameObject, ProjectileSpeed);

                    // Update the wave offset for the next projectile.
                    waveOffset += waveSpreadIncrement;
                }
            }

            // CrissCrossPattern
            else if (CrissCrossPattern)
            {
                if (alternatePattern == true)
                {
                    // Up
                    projectileThrower.Throw(currentProjectilePrefab, transform.position + Vector3.up, gameObject, ProjectileSpeed);
                    // Down
                    projectileThrower.Throw(currentProjectilePrefab, transform.position + Vector3.down, gameObject, ProjectileSpeed);
                    // Right
                    projectileThrower.Throw(currentProjectilePrefab, transform.position + Vector3.right, gameObject, ProjectileSpeed);
                    // Left
                    projectileThrower.Throw(currentProjectilePrefab, transform.position + Vector3.left, gameObject, ProjectileSpeed);
                    alternatePattern = false;
                }
                else
                {
                    projectileThrower.Throw(currentProjectilePrefab, transform.position + Vector3.up + Vector3.right, gameObject, ProjectileSpeed);
                    projectileThrower.Throw(currentProjectilePrefab, transform.position + Vector3.up + Vector3.left, gameObject, ProjectileSpeed);
                    projectileThrower.Throw(currentProjectilePrefab, transform.position + Vector3.down + Vector3.right, gameObject, ProjectileSpeed);
                    projectileThrower.Throw(currentProjectilePrefab, transform.position + Vector3.down + Vector3.left, gameObject, ProjectileSpeed);
                    alternatePattern = true;
                }
            }
            else
            {
                projectileThrower.Throw(currentProjectilePrefab, targetPosition, gameObject, ProjectileSpeed);
            }
        }
        else
        {
            Debug.Log("Player is null!");
        }
    }
}
