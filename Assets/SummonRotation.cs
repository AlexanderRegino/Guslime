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
        SpawnProjectiles();
    }

    void SpawnProjectiles()
    {
        for (int i = 0; i < projectiles.Length; i++)
        {
            float angle = i * 90f;
            float radianAngle = angle * Mathf.Deg2Rad;
            Vector3 offset = new Vector3(Mathf.Cos(radianAngle), Mathf.Sin(radianAngle), 0f) * radius;

            // Instantiate the projectile and set the current GameObject as its parent
            projectiles[i] = Instantiate(RotationPrefab, transform.position + offset, Quaternion.identity, transform);
            projectiles[i].transform.parent = transform;
        }
    }

    void Update()
    {
        RotateProjectiles();
    }

    void RotateProjectiles()
    {
        for (int i = 0; i < projectiles.Length; i++)
        {
            float angle = i * 90f;
            float radianAngle = angle * Mathf.Deg2Rad;
            Vector3 offset = new Vector3(Mathf.Cos(radianAngle), Mathf.Sin(radianAngle), 0f) * radius;

            // Ensure the projectiles stay within the specified distance from the center object
            projectiles[i].transform.position = transform.position + offset;

            // Update the rotation of each projectile
            projectiles[i].transform.RotateAround(transform.position, rotationAxis, rotationSpeed * Time.deltaTime);
        }
    }
}
