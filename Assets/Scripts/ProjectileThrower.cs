using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileThrower : MonoBehaviour
{
    private float lastProjectileThrownTime;

    public float shotgunProjectileLifetime = 5f;
    public float slimeProjectileLifetime = 7f;

    public void Throw(GameObject projectilePrefab, Vector3 targetPosition, GameObject host, float ProjectileSpeed)
    {
        Debug.Log("The host is ", host);
        // Check if enough time has passed since the last projectile was thrown.
     
            // Check if the projectilePrefab is the shotgunProjectile.
            if (projectilePrefab.name == "shotgunProjectile")
            {
                // Calculate the direction towards the target position.
                Vector3 throwDirection = targetPosition - transform.position;
                throwDirection.Normalize();

                // Calculate angles for the additional projectiles.
                float angleLeft = -15f; // 15 degrees left
                float angleRight = 15f; // 15 degrees right

                // Instantiate the main projectile.
                FireProjectile(projectilePrefab, throwDirection, host, ProjectileSpeed);

                // Instantiate the left projectile.
                Quaternion leftRotation = Quaternion.Euler(0, 0, angleLeft);
                Vector3 leftDirection = leftRotation * throwDirection;
                FireProjectile(projectilePrefab, leftDirection, host, ProjectileSpeed);

                // Instantiate the right projectile.
                Quaternion rightRotation = Quaternion.Euler(0, 0, angleRight);
                Vector3 rightDirection = rightRotation * throwDirection;
                FireProjectile(projectilePrefab, rightDirection, host, ProjectileSpeed);
            }
            else if (projectilePrefab.name == "slimeProjectile" || projectilePrefab.name == "cannonProjectile")
            {
                // Instantiate the slimeProjectile with the regular behavior.
                Vector3 throwDirection = targetPosition - transform.position;
                throwDirection.Normalize();
                FireProjectile(projectilePrefab, throwDirection, host, ProjectileSpeed);
            }
            else if ( projectilePrefab.name == "cannonProjectile")
            {
                // Instantiate the slimeProjectile with the regular behavior.
                Vector3 throwDirection = targetPosition - transform.position;
                throwDirection.Normalize();
                FireProjectile(projectilePrefab, throwDirection, host, ProjectileSpeed);
            }
            else
                {
                    Debug.LogWarning("Unknown projectile prefab: " + projectilePrefab.name);
                }

            // Update the last time a projectile was thrown.
            lastProjectileThrownTime = Time.time;
        
    }

    // Helper function to instantiate and set properties of projectiles.
    private void FireProjectile(GameObject projectilePrefab, Vector3 direction, GameObject host, float speed)
    {
        Debug.Log("The host is ", host);
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        slimeballTouch touchScript = projectile.GetComponent<slimeballTouch>();

        if (touchScript != null)
        {
            touchScript.setHost(host);
        }

        rb.velocity = direction * speed;

        // Set the lifetime of the projectile based on its type.
        float projectileLifetime = 0f;
        if (projectilePrefab.name == "shotgunProjectile")
        {
            projectileLifetime = shotgunProjectileLifetime;
        }
        else if (projectilePrefab.name == "slimeProjectile" )
        {
            projectileLifetime = slimeProjectileLifetime;
        }
        else  //(projectilePrefab.name == "cannonProjectile"))
        {
            projectileLifetime = slimeProjectileLifetime;
        }

        // Destroy the projectile after the specified lifetime.
        Destroy(projectile, projectileLifetime);
    }

}
