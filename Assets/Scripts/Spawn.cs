using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
   // public GameObject prefabToSpawn;      // Normal prefab
   // public GameObject mediumprefabToSpawn; // Medium prefab
  //  public GameObject uncommonprefabToSpawn; //Rarer than medium
   // public GameObject rarerprefabToSpawn;  // Rare prefab
   // public GameObject rarestprefabToSpawn; // Rarest prefab

    public GameObject FirstPrefab; //Stationary Sentry
    public GameObject SecondPrefab; //Cannonball Sentry
    public GameObject ThirdPrefab; //Fighter Chaser Sentry
    public GameObject FourthPrefab; //Melee Chaser SEntry
    public GameObject FifthPrefab; //Spawn Rotation Sentry
    public GameObject SixthPrefab; //Shotgun Sentry
    public GameObject SeventhPrefab; //Plus Sentry
    public GameObject EigthPrefab; //Wave Sentry
    public GameObject NinthPrefab; //Burst Fire Sentry
    public GameObject TenthPrefab; //Spread Sentry


    public float initialSpawnInterval = 9.0f;
    public float minSpawnInterval = 3.0f;

    private void Start()
    {
        // Start the spawning coroutine when the script is initialized.
        StartCoroutine(SpawnObjectsWithDecreasingInterval());

        string currentLevel = PlayerPrefs.GetString("CurrentLevel");
        if (currentLevel == "Snow") 
        {
            Time.timeScale = Time.timeScale * 1.25f;
        }
    }

    private IEnumerator SpawnObjectsWithDecreasingInterval()
    {
        while (true)
        {
            float randomValue = Random.value;
            GameObject prefabToSpawnNow = null;

            // Determine which prefab to spawn based on random chance or PlayerPrefs value.
            string currentLevel = PlayerPrefs.GetString("CurrentLevel", "Basic");

            if (currentLevel == "Basic")
            {
                // Assign prefabs based on Basic level
                if (randomValue < 0.4f) prefabToSpawnNow = FirstPrefab;   // 40% chance for FirstPrefab
                else if (randomValue < 0.6f) prefabToSpawnNow = SecondPrefab; // 20% chance for SecondPrefab
                else if (randomValue < 0.8f) prefabToSpawnNow = NinthPrefab;  // 20% chance for NinthPrefab
                else if (randomValue < 0.9f) prefabToSpawnNow = SixthPrefab;  // 10% chance for SixthPrefab
                else prefabToSpawnNow = EigthPrefab;  // 10% chance for EigthPrefab
            }
            else if (currentLevel == "Grass")
            {
                // Assign prefabs based on Grass level
                if (randomValue < 0.4f) prefabToSpawnNow = FourthPrefab;  // 40% chance for FourthPrefab
                else if (randomValue < 0.6f) prefabToSpawnNow = ThirdPrefab;   // 20% chance for ThirdPrefab
                else if (randomValue < 0.8f) prefabToSpawnNow = SeventhPrefab; // 20% chance for SeventhPrefab
                else if (randomValue < 0.9f) prefabToSpawnNow = TenthPrefab;   // 10% chance for TenthPrefab
                else prefabToSpawnNow = FifthPrefab;  // 10% chance for FifthPrefab
            }
            else if (currentLevel == "Snow")
            {
                // Assign prefabs based on Snow level
                if (randomValue < 0.4f) prefabToSpawnNow = NinthPrefab;  // 40% chance for NinthPrefab
                else if (randomValue < 0.6f) prefabToSpawnNow = FifthPrefab;   // 20% chance for FifthPrefab
                else if (randomValue < 0.8f) prefabToSpawnNow = EigthPrefab; // 20% chance for EigthPrefab
                else if (randomValue < 0.9f) prefabToSpawnNow = TenthPrefab;   // 10% chance for TenthPrefab
                else prefabToSpawnNow = SixthPrefab;  // 10% chance for SixthPrefab
        
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

            // Check if the difficulty is set to "Easy"
            if (PlayerPrefs.GetString("DifficultyLevel") == "Easy") //Debuff Enemies if easy mode is enabled
            {
                // Modify requestProjectile variables
                var requestProjectile = newDropped.GetComponent<requestProjectile>();
                if (requestProjectile != null)
                {
                   requestProjectile.MultiplyRequestCooldown(1.65f); // 1.35f; // 35% slower firing speed
                    requestProjectile.ProjectileSpeed *= 0.65f; // 35% slower projectile speed
                        //requestProjectile.MultiplyRequestCooldown(0.65f);
                }

                // Modify MoveTowardsPlayer variables
                var moveTowardsPlayer = newDropped.GetComponent<MoveTowardsPlayer>();
                if (moveTowardsPlayer != null)
                {
                      moveTowardsPlayer.MultiplyMoveSpeed(0.65f); // 0.65f; // 35% slower move speed
                }
            }

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
