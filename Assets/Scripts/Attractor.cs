using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    [SerializeField] AnimationCurve speedCurve; // Speed curve to control the speed based on distance
    [SerializeField] float maxSpeed = 5.0f; // Maximum speed
    [SerializeField] float attractionRangeMultiplier = 2.0f; // Multiplier to control the attraction range
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
            float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

            // Increase the range at which the attraction effect starts
            float effectiveAttractionRange = maxSpeed * attractionRangeMultiplier;

            // Evaluate the speed based on the distance using the curve
            float speedMultiplier = speedCurve.Evaluate(1.0f - Mathf.Clamp01(distanceToPlayer / effectiveAttractionRange));

            // Calculate the final speed
            float currentSpeed = speedMultiplier * maxSpeed;

            // Calculate the velocity
            Vector3 velocity = direction * currentSpeed;

            // Use the Movement script's MoveRB method to move the entity with a Rigidbody2D.
            GetComponent<Movement>().MoveRB(velocity);
        }
        else
        {
            Debug.Log("Player is null!");
        }
    }
}
