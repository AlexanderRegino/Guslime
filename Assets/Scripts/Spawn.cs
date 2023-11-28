using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefabToSpawn;      // Normal prefab
   
    public GameObject mediumprefabToSpawn; // Medium prefab
    public GameObject uncommonprefabToSpawn; //Rarer than medium
    public GameObject rarerprefabToSpawn;  // Rare prefab
    public GameObject rarestprefabToSpawn; // Rarest prefab
  
    public float initialSpawnInterval = 9.0f;
    public float minSpawnInterval = 3.0f;

    private void Start()
    {
        // Start the spawning coroutine when the script is initialized.
        StartCoroutine(SpawnObjectsWithDecreasingInterval());
    }

    private IEnumerator SpawnObjectsWithDecreasingInterval()
    {
        while (true)
        {
            float randomValue = Random.value;
            GameObject prefabToSpawnNow = null;

            // Determine which prefab to spawn based on random chance.
            if (randomValue < 0.4f)  // Adjust this value for the uncommonprefabToSpawn
            {
                prefabToSpawnNow = prefabToSpawn;  // 40% chance for prefabToSpawn
            }
            else if (randomValue < 0.6f)
            {
                prefabToSpawnNow = mediumprefabToSpawn;  // 20% chance for mediumprefabToSpawn
            }
            else if (randomValue < 0.8f)
            {
                prefabToSpawnNow = uncommonprefabToSpawn;  // 20% chance for uncommonprefabToSpawn
            }
            else if (randomValue < 0.9f)
            {
                prefabToSpawnNow = rarerprefabToSpawn;  // 10% chance for rarerprefabToSpawn
            }
            else
            {
                prefabToSpawnNow = rarestprefabToSpawn;  // 10% chance for rarestprefabToSpawn
            }

            // Spawn the selected prefab with the current interval.
            SpawnObjectAtDropLocation(prefabToSpawnNow);

            // Decrease the spawn interval (but don't go below minSpawnInterval).
            initialSpawnInterval = Mathf.Max(initialSpawnInterval - 1.0f, minSpawnInterval);

            // Wait for the current interval.
            yield return new WaitForSeconds(initialSpawnInterval);
        }
    }

    public void SpawnObjectAtDropLocation(GameObject prefab)
    {
        if (prefab != null)
        {
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                float randomX = Random.Range(0f, 1f);
                Vector3 spawnPoint = mainCamera.ViewportToWorldPoint(new Vector3(randomX, 1f, 0f));
                spawnPoint.z = 0f;
                GameObject newDropped = Instantiate(prefab, spawnPoint, prefab.transform.rotation);
                // Destroy(newDropped, 5); // You can destroy it if needed.
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
}
