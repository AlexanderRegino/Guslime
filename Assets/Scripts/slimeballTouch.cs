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

        // Check if the parent object has the "Player" or "Enemy" tag and it's not the same as the host.
        if (parentObject.CompareTag("Player") && parentObject != host)
        {
            Debug.Log("Hit something with HP (Player)");

            // Attempt to get the HP value from the parent object.
            var healthComponent = parentObject.GetComponent<Health>();
            healthComponent.TakeDamage(1);
            Destroy(gameObject);
        }
        else if (parentObject.CompareTag("Enemy") && parentObject != host && host.CompareTag("Player")) // Add this condition to prevent friendly fire
        {
            Debug.Log("Hit something with HP (Enemy)");

            // Attempt to get the HP value from the parent object.
            var healthComponent = parentObject.GetComponent<Health>();
            healthComponent.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
