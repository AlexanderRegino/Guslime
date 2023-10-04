using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoints : MonoBehaviour
{
    [SerializeField] Spawn spawner;
    [SerializeField] GameObject points;
    [SerializeField] GameObject hazard;
    private float initialDelay = 3f;
    private float repeatRate = 1f;

    public bool canSpawn = false; // Public boolean variable

    void Start()
    {
        StartCoroutine(SpawnRepeatedly());
    }

    IEnumerator SpawnRepeatedly()
    {
        // Create a list of prefabs to spawn
        List<GameObject> prefabsToSpawn = new List<GameObject>
        {
            points,
            hazard
            // Add more prefabs to the list if needed
        };

        while (canSpawn) // Check the boolean variable
        {
            // Loop through the prefabs and spawn objects
            foreach (GameObject prefab in prefabsToSpawn)
            {
                spawner.SpawnObjectAtDropLocation(prefab);
                yield return new WaitForSeconds(repeatRate);
            }
        }
    }
}
