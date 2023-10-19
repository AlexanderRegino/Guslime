using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class requestProjectile : MonoBehaviour
{
    [SerializeField] float requestCooldown = 1.0f; // Time in seconds between requesting projectiles
    [SerializeField] GameObject currentProjectilePrefab;
    private GameObject player; // Reference to the player GameObject
    ProjectileThrower projectileThrower;
    private float lastRequestTime;
    public float ProjectileSpeed = 5;
    void Awake()
    {
        projectileThrower = GetComponent<ProjectileThrower>();
        player = GameObject.FindGameObjectWithTag("Player"); // Assuming you've tagged the player object with "Player".
    }

    void Update()
    {
        // Check if enough time has passed since the last projectile was requested.
        if (Time.time - lastRequestTime >= requestCooldown)
        {
            if (player != null && gameObject != null) // Check if the player reference is valid
            {
                // Request a projectile aiming at the player's position.
                Vector3 targetPosition = player.transform.position;
                Debug.Log("GameObject is", gameObject);
             
                projectileThrower.Throw(currentProjectilePrefab, targetPosition, gameObject, ProjectileSpeed);
            }
            else
            {
                Debug.Log("Player is null!");
            }

            // Update the last time a projectile was requested.
            lastRequestTime = Time.time;
        }
    }
}
