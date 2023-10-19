using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
    [SerializeField] int value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Incrementing Points");
            Debug.Log("Value");
            pointsManager.instance.UpdatePoints(value);
            Destroy(gameObject);
        }
    }
}
