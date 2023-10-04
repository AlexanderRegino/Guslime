using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefabToSpawn; // Declare the variable at the class level.

    // Function to spawn a GameObject at a specific position within the camera's view.
    public void SpawnObjectAtLocation(Vector3 position, GameObject prefab)
    {
        if (prefab != null)
        {
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                Vector3 spawnPoint = mainCamera.ViewportToWorldPoint(position);
                spawnPoint.z = 0f; // Adjust this value as needed.
                Instantiate(prefab, spawnPoint, Quaternion.identity);
            }
            else
            {
                Debug.LogError("Main camera not found!");
            }
        }
        else
        {
            Debug.LogError("Prefab is not assigned!");
        }
    }
    public void SpawnObjectAtDropLocation(GameObject prefab)
    {
        if (prefab != null)
        {
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                // Define a random X position within the camera's view.
                float randomX = Random.Range(0f, 1f);
                Vector3 spawnPoint = mainCamera.ViewportToWorldPoint(new Vector3(randomX, 1f, 0f));

                spawnPoint.z = 0f; // Adjust this value as needed.
                GameObject newDropped = Instantiate(prefab, spawnPoint, prefab.transform.rotation);
                Destroy(newDropped, 5);
            }
            else
            {
                Debug.LogError("Main camera not found!");
            }
        }
        else
        {
            Debug.LogError("Prefab is not assigned!");
        }
        
    }

    // Example usage:
    void Update()
    {
        // Call the SpawnObjectAtLocation function with a specific position and prefab (e.g., the center of the screen and a prefab you assign in the Inspector).
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPosition = new Vector3(0.5f, 0.5f, 0f);
            SpawnObjectAtDropLocation(prefabToSpawn); // Access the prefab from the class-level field.
        }
    }
}





