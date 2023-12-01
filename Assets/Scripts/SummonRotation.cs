using UnityEngine;

public class SummonRotation : MonoBehaviour
{
    [SerializeField] GameObject RotationPrefab;
    private GameObject[] projectiles = new GameObject[4];

    private float rotationSpeed = 10f; // Degrees per second
    public float radius = 2f; // Adjust this radius based on your needs
    public Vector3 rotationAxis = Vector3.forward;

    void Start()
    {
        // Start the coroutine to spawn projectiles every 10 seconds
        StartCoroutine(SpawnProjectilesCoroutine());
    }

    System.Collections.IEnumerator SpawnProjectilesCoroutine()
    {
        while (true)
        {
            SpawnProjectiles();
            yield return new WaitForSeconds(10f); // Wait for 10 seconds before spawning again
        }
    }

    void SpawnProjectiles()
    {
        for (int i = 0; i < projectiles.Length; i++)
        {
            float angle = i * 90f;
            float radianAngle = angle * Mathf.Deg2Rad;
            Vector3 offset = new Vector3(Mathf.Cos(radianAngle), Mathf.Sin(radianAngle), 0f) * radius;

            // Instantiate the projectile and set the current GameObject as its parent
            projectiles[i] = Instantiate(RotationPrefab, transform.position + offset, Quaternion.identity, null);
             if (PlayerPrefs.GetString("DifficultyLevel") == "Easy") //Debuff Enemies if easy mode is enabled
            {

                // Modify requestProjectile variables
                var requestProjectile = projectiles[i].GetComponent<requestProjectile>();
                if (requestProjectile != null)
                {
                   requestProjectile.MultiplyRequestCooldown(1.65f); // 1.35f; // 35% slower firing speed
                    requestProjectile.ProjectileSpeed *= 0.65f; // 35% slower projectile speed
                        //requestProjectile.MultiplyRequestCooldown(0.65f);
                }

                // Modify MoveTowardsPlayer variables
                var moveTowardsPlayer = projectiles[i].GetComponent<MoveTowardsPlayer>();
                if (moveTowardsPlayer != null)
                {
                      moveTowardsPlayer.MultiplyMoveSpeed(0.65f); // 0.65f; // 35% slower move speed
                }
            }
          //  projectiles[i].transform.parent = transform;

        }
    }

    void Update()
    {
        // You can put any per-frame logic here if needed
    }
}
