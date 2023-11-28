using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeballTouch : MonoBehaviour
{
    private GameObject host; // Reference to the player GameObject

    public void setHost(GameObject newHost)
    {
        host = newHost;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Get the parent GameObject of the collided object.
        GameObject parentObject = collision.transform.parent != null ? collision.transform.parent.gameObject : collision.gameObject;

        // Check if the parent object is the same as the host.
        if (parentObject == host)
        {
            return; // Skip the rest of the code if the object is the same as the host.
        }

        // Check if the parent object has the "Player" tag.
        if (parentObject.CompareTag("Player"))
        {
            Debug.Log("Hit something with HP (Player)");

            // Attempt to get the HP value from the parent object.
            var healthComponent = parentObject.GetComponent<Health>();
            healthComponent.TakeDamage(1);
            Destroy(gameObject);
        }
        // Check if the parent object has the "Enemy" tag and the host is the player.
        else if (parentObject.CompareTag("Enemy") && host != null && host.CompareTag("Player"))
        {
            Debug.Log("Hit something with HP (Enemy)");

            // Attempt to get the HP value from the parent object.
            var healthComponent = parentObject.GetComponent<Health>();

            // Check if healthComponent is not null before applying damage
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1);
            }

            Destroy(gameObject);
        }

    }
}
