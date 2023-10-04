using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
   
    //You could make  variables accessible but make them seriazle field
    [SerializeField] int HP = 10;
    [SerializeField] float speed = 5;
    [SerializeField] Movement movement;
    public bool upKeyPressed = false;
    public bool downKeyPressed  = false;
    public bool leftKeyPressed = false;
    public bool rightKeyPressed = false;

    void Awake() //Find References, ensure nothing is null but this will come in later 
    { //GetComponent is O(N) 
        Debug.Log("Awake!");
        movement = GetComponent<Movement>();
    }
    void Start()
    {
        Debug.Log("Hello from function");
        Debug.Log("New Coding Method");
    }
    public bool CheckMultiKey(bool RightKey, bool LeftKey, bool upKey, bool downKey)
    {
        Debug.Log(RightKey);
        Debug.Log(LeftKey);
        Debug.Log(upKey);
        Debug.Log(downKey);
        if (RightKey == false && LeftKey == false && upKey == false && downKey == false)
        {
            Debug.Log("Input is clean");
            return true;
        }
        else
        {
            Debug.Log("Input is dirty");
            return false;
        }
    }
    void FixedUpdate()
    {
        Vector3 vel = Vector3.zero;



        if (Input.GetKey("d"))
        {
            vel.x = speed;
            Debug.Log("d key was pressed");
        }
        if (Input.GetKey("a"))
        {
            vel.x = -speed;
            Debug.Log("a key was pressed");
        }
        if (Input.GetKey("w"))
        {
            vel.y = speed;
            Debug.Log("a key was pressed");
        }
        if (Input.GetKey("s"))
        {
            vel.y = -speed;
            Debug.Log("a key was pressed");
        }
        movement.MoveRB(vel);
    }
    // Update is called once per frame
    void Update() //Time Delta Time multplications can ignore frame weirdness.
    {
        
 
}
}

//Unity can tag items and put them in a hash table that can be found as an O(1) Operation 
//GameObject.FindGameObjectWith