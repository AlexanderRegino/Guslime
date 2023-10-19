using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f; // Speed at which the entity moves towards the player
    private GameObject player; // Reference to the player GameObject

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Assuming you've tagged the player object with "Player".
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 playerPosition = player.transform.position;
            Vector3 direction = playerPosition - transform.position;
            direction.Normalize();

            // Use the Movement script's MoveRB method to move the entity with a Rigidbody2D.
            GetComponent<Movement>().MoveRB(direction * moveSpeed);
        }
        else
        {
            Debug.Log("Player is null!");
        }
    }
}
