using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemy : MonoBehaviour
{
    [SerializeField] float requestCooldown = 1.0f; // Time in seconds between requesting projectiles
    [SerializeField] GameObject currentProjectilePrefab;
    [SerializeField] GameObject player; // Reference to the player GameObject
    ProjectileThrower projectileThrower;
    private float lastRequestTime;
    public float ProjectileSpeed = 5;
    void Awake()
    {
        projectileThrower = GetComponent<ProjectileThrower>();
    }

    void Update()
    {
        // Check if enough time has passed since the last projectile was requested.
        if (Time.time - lastRequestTime >= requestCooldown)
        {
            if (player != null) // Check if the player reference is valid
            {
                // Request a projectile aiming at the player's position.
                Vector3 targetPosition = player.transform.position;
                projectileThrower.Throw(currentProjectilePrefab, targetPosition, gameObject, ProjectileSpeed);
            }

            // Update the last time a projectile was requested.
            lastRequestTime = Time.time;
        }
    }
}
