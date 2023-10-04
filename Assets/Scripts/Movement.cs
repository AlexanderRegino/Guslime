using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    void Awake()
    {
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void MoveTransform(Vector3 vel)
    {
        print(vel);
        transform.position += vel * Time.fixedDeltaTime;
    }
    public void MoveRB(Vector3 vel)
    {
        Debug.Log(vel);
        rb.velocity = vel;
    }
}