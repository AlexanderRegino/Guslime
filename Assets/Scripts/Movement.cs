using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
     
    }
    public void MoveTransform(Vector3 vel)
    {
        print(vel);
        transform.position += vel * Time.fixedDeltaTime;
    }
    public void MoveRB(Vector3 vel)
    {
  
        rb.velocity = vel;
    }
}