using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int HP = 10;
    [SerializeField] float speed = 5;
    [SerializeField] Movement movement;
    public GameObject currentProjectilePrefab;
    public GameObject alternateProjectilePrefab;
    public float requestCooldown = 2f; // Time in seconds between requesting projectiles
    public float ProjectileSpeed = 5;
    ProjectileThrower projectileThrower;
    private float lastRequestTime;

    void Awake()
    {
        movement = GetComponent<Movement>();
        projectileThrower = GetComponent<ProjectileThrower>();
        lastRequestTime = -requestCooldown; // Initialize the last request time to allow the first request immediately.

        // Check PlayerPrefs for the selected player
        string playerOption = PlayerPrefs.GetString("PlayerOption"); // Assuming "PlayerOption" is the key you are using

        // If the player option is "MetalSlime," set the current projectile prefab to the alternate one
        Debug.Log(playerOption);
        if (playerOption == "MetalSlime")
        {
            currentProjectilePrefab = alternateProjectilePrefab;
            SetSpriteColorToGrey();
        }
    }
    void SetSpriteColorToGrey()
    {
        // Change the sprite renderer color to grey
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    void FixedUpdate()
    {
        Vector3 vel = Vector3.zero;

        if (Input.GetKey("d"))
        {
            vel.x = speed;
        }
        if (Input.GetKey("a"))
        {
            vel.x = -speed;
        }
        if (Input.GetKey("w"))
        {
            vel.y = speed;
        }
        if (Input.GetKey("s"))
        {
            vel.y = -speed;
        }
        movement.MoveRB(vel);
    }

    void Update()
    {
        // Check for mouse input and cooldown.
        if (Input.GetMouseButtonDown(0) && Time.time - lastRequestTime >= requestCooldown)
        {
            // Get the mouse position in world coordinates.
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Call the Throw method with the projectile prefab and mouse position.
            projectileThrower.Throw(currentProjectilePrefab, mousePosition, gameObject, ProjectileSpeed);

            // Update the last request time.
            lastRequestTime = Time.time;
        }
    }
}
